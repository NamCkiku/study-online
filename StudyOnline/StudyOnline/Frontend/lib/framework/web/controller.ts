/// <reference path="../../../../typings/curama.d.ts"/>

import * as express from "express";
import * as decorators from "../decorators";
import * as intravenous from "intravenous";
import * as forms from "forms";
import * as bluebird from "bluebird";

import { HttpStatusCodes } from "../statusCodes";

const X_REQUEST_ID_HEADER_NAME = "x-request-id";

export enum Methods {
    Get, Post, All
}

export class Method {
    static get(path: string): MethodDecorator {
        return Method.addMetod(Methods.Get, path);
    }
    static post(path: string): MethodDecorator {
        return Method.addMetod(Methods.Post, path);
    }

    private static addMetod(method: Methods, path: string): MethodDecorator {
        return (target: Object, key: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);
            metaFunction.meta.methods.push({
                method: method,
                path: path
            });
        };
    }
}

let METHOD_MAP = {};
METHOD_MAP[Methods.Get] = "get";
METHOD_MAP[Methods.Post] = "post";
METHOD_MAP[Methods.All] = "all";

export interface FormHandleResult<T> {
    error: boolean;
    success: boolean;
    form: forms.IBoundForm<T>;
    data: T;
}

export class Controller {
    public router: express.Router;

    protected className: string;
    protected controllerName: string;

    constructor() {
        this.className = Object.getPrototypeOf(this).constructor.name;
        this.controllerName = this.className.replace(/Controller/, "");
        /* magic: Need to camelify this string */
        this.controllerName = this.controllerName.substring(0, 1).toLowerCase() + this.controllerName.substring(1);
    }

    protected handleForm<T>(req: express.Request, form: forms.IForm<T>): Promise<FormHandleResult<T>> {
        return new Promise<FormHandleResult<T>>((resolve, reject) => {
            let callbacks: forms.ICallbacks<T> = {
                success: (f): void => {
                    resolve({
                        error: false,
                        success: true,
                        form: f,
                        data: f.data
                    });
                },
                error: (f): void => {
                    resolve({
                        error: true,
                        success: false,
                        form: f,
                        data: f.data
                    });
                }
            };
            callbacks.empty = callbacks.error;
            form.handle(req, callbacks);
        });
    }

    /**
     * Registers controller methods as cations if they have @Method decorator.
     * @param {intravenous.IContainer} container Container to resolve dependencies from
     * @param {express.Router}         router    Router to register actions with
     */
    public _registerController(container: intravenous.IContainer, router: express.Router): void {
        this.router = router;

        for (let f of this.enumerateMethods(this)) {
            if (!this[f].meta) {
                continue;
            }

            let mf = <decorators.IMetaFunction>this[f];
            for (let method of mf.meta.methods) {
                let routerMethod: Function = this.router[METHOD_MAP[method.method]].bind(this.router);


                let customMiddlewares: express.RequestHandler[] = [];
                if (method.path.startsWith("!")) {
                    let originalPath = method.path;
                    method.path = "/:url(*)";
                    let parameterResolverMiddleware = container.get("ParameterResolverMiddleware");
                    customMiddlewares.push(parameterResolverMiddleware.create(originalPath.substr(1)));
                }

                let dispatcher = (req: express.Request, res: express.Response, done: express.NextFunction): void => {
                    let scope = container.create();
                    scope.register("RequestId", req.headers[X_REQUEST_ID_HEADER_NAME] || "unknown");
                    let controller = scope.get(this.className);
                    if (!controller) {
                        // O.o
                    }

                    let middleware = (mf.meta.isProxy ? mf() : mf).bind(controller);
                    let middlewareWrapper = async function (request: express.Request, response: express.Response, next: express.NextFunction): Promise<void> {
                        try {
                            this.extendResponse(request, response, next, middleware);
                            let result = middleware(request, response, next);
                            if (result instanceof Promise || result instanceof bluebird) {
                                /* tslint:disable:no-unused-expression We need the side effect, not the return value*/
                                await result;
                                /* tslint:enable */
                            }
                        } catch (error) {
                            next(error);
                        }
                    }.bind(controller);

                    let resolveMiddlewares = this.resolveMiddlewares.bind(controller);

                    let stack: express.RequestHandler[] = [].concat(
                        customMiddlewares,
                        resolveMiddlewares(mf.meta.middleware.before),
                        middlewareWrapper,
                        resolveMiddlewares(mf.meta.middleware.after)
                    );

                    let idx = 0;
                    next();
                    function next(err?: any): void {
                        if (err && err === "route") {
                            return done();
                        }
                        let middleware = stack[idx++];
                        if (!middleware) {
                            return done(err);
                        }

                        if (err) {
                            return done(err);
                        } else {
                            middleware(req, res, next);
                        }
                    }
                };

                let args = [method.path, dispatcher];
                routerMethod.apply(this.router, args);
            }
        }
    }

    /* tslint:disable:no-unused-variable This function is used indirectly from `middlewareWrapper` in `register method` */
    private extendResponse(req: express.Request, res: express.Response, next: express.NextFunction, currentMethod: Function): void {
    /* tslint: enable */
        let methodName = currentMethod.name.replace("bound ", "");

        let viewMethod = (model?: Object): void => {
            let typeofModel = typeof model;


            let viewName: string = `${this.controllerName}/${methodName}.jinja2`;
            let viewModel: Object = null;

            if (typeofModel === "object") {
                viewModel = model;
            } else {
                viewModel = {};
            }

            try {
                res.render(viewName, viewModel);
            } catch (error) {
                next(error);
            }
        };

        let namedViewMethod = (name: string, model?: Object): void => {
            let typeofName = typeof name;
            let typeofModel = typeof model;

            let viewName: string = name;
            let viewModel: Object = null;

            if (viewName.indexOf("/") === -1) {
                viewName = `${this.controllerName}/${viewName}.jinja2`;
            }

            if (typeofModel === "object") {
                viewModel = model;
            } else {
                viewModel = {};
            }

            try {
                res.render(viewName, viewModel);
            } catch (error) {
                next(error);
            }
        };

        let notFoundMethod = (message?: string): void => {
            let error: any = new Error();
            error.statusCode = HttpStatusCodes.NotFound;
            next(error);
        };

        res.view = viewMethod;
        res.namedView = namedViewMethod;
        res.notFound = notFoundMethod;

        let mobileRegex = /(iPhone|Android)/;
        let isMobile = (): boolean => {
            let ua = req.headers["user-agent"];
            return mobileRegex.test(ua);
        };

        let isAjax = (): boolean => {
            return req.xhr || (req.headers["accept"] && req.headers["accept"].indexOf("json") !== -1);
        };

        req.isMobile = isMobile;
        req.isAjax = isAjax;
    }

    private resolveMiddlewares(middlewareResolvers: decorators.MiddlewareResolver[]): express.RequestHandler[] {
        let result: express.RequestHandler[] = [];
        for (let res of middlewareResolvers) {
            result.push(res.bind(this)(this).bind(this));
        }
        return result;
    }

    private enumerateMethods(obj: Object): string[] {
        let result = [];
        for (let name of Object.getOwnPropertyNames(Object.getPrototypeOf(obj))) {
            let method = obj[name];
            if (!(method instanceof Function) || name === "constructor") {
                continue;
            }
            result.push(name);
        }
        return result;
    }
}
