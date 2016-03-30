/// <reference path="../../../../typings/curama.d.ts"/>

import * as express from "express";
import * as decorators from "../decorators";

import { HttpStatusCodes } from "../statusCodes";

export class Middleware {
    static proxy(target: Object, key: string, descriptor: TypedPropertyDescriptor<any>): void {
        let metaFunction = decorators.makeMeta(descriptor.value);
        metaFunction.meta.isProxy = true;
    }

    static before(middlewareResolver: decorators.MiddlewareResolver): MethodDecorator {
        return (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);
            metaFunction.meta.middleware.before.push(middlewareResolver);
        };
    }

    static after(middlewareResolver: decorators.MiddlewareResolver): MethodDecorator {
        return (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);
            metaFunction.meta.middleware.after.push(middlewareResolver);
        };
    }

    static reqireAuth(redirect?: string): MethodDecorator {
        return (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);

            let authMiddleware = (req: express.Request, res: express.Response, next: express.NextFunction): any => {
                if (req.isAuthenticated() && req.user && req.user.accountType === 2) {
                    return next();
                }

                if (redirect) {
                    return res.redirect(`${redirect}?return=${req.url}`);
                }
                return res.status(HttpStatusCodes.Unauthorized);
            };

            metaFunction.meta.middleware.before.push(() => authMiddleware);
        };
    }

    static requireStoreAuth(): MethodDecorator {
        return (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);

            let authMiddleware = (req: express.Request, res: express.Response, next: express.NextFunction): any => {
                if (req.isAuthenticated() && req.user && req.user.accountType === 2) {
                    return next();
                }

                return res.redirect(`/shop/login/?return=${req.url}`);
            };

            metaFunction.meta.middleware.before.push(() => authMiddleware);
        };
    }

    static requireUserAuth(): MethodDecorator {
        return (target: Object, propertyKey: string, descriptor: TypedPropertyDescriptor<any>) => {
            let metaFunction = decorators.makeMeta(descriptor.value);

            let authMiddleware = (req: express.Request, res: express.Response, next: express.NextFunction): any => {
                if (req.isAuthenticated() && req.user && req.user.accountType === 1) {
                    return next();
                }

                return res.redirect(`/login/?return=${req.url}`);
            };

            metaFunction.meta.middleware.before.push(() => authMiddleware);
        };
    }
}
