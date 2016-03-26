/// <reference path="../../../../typings/curama.d.ts"/>

import * as express from "express";
import * as wrench from "wrench";
import * as path from "path";
import * as intravenous from "intravenous";

import { Dependency } from "../ioc/dependency";

export interface ParameterResolutionContext {
    url: string;
    originalUrl: string;
}

export interface ParameterResolutionResult {
    error?: Error;
    success: boolean;
    url: string;
    result: Object;
}

export interface ParameterResolvers {
    [key: string]: ParameterResolverBase;
}

interface ResolverChainLink {
    paramName?: string;
    resolver?: ParameterResolverBase;
    resolitionResult?: ParameterResolutionResult;
    optional?: boolean;
    isParameter?: boolean;
}

export abstract class ParameterResolverBase {
    constructor(name: string) {
        this.name = name;
    }

    public name: string;
    public abstract async resolve(ctx: ParameterResolutionContext): Promise<ParameterResolutionResult>;

    protected splitParts(url: string): string[] {
        let urlParts: string[] = [];
        let index = 0;
        /* tslint:disable:no-conditional-assignment I know what i am doing here*/
        while ((index = url.indexOf("/", index)) !== -1) {
        /* tslint:enable */
            index++;
            if (index === 1) {
                continue;
            }
            urlParts.push(url.substring(0, index));
        }

        return urlParts;
    }
}

const DEFAULT_RESOLVER_NAME = "_default";
export class DefaultParameterResolver extends ParameterResolverBase {
    constructor() {
        super(DEFAULT_RESOLVER_NAME);
    }

    public async resolve(ctx: ParameterResolutionContext): Promise<ParameterResolutionResult> {
        let regex = /\/([\w\d_\-]+)(\/)?/;
        let value = regex.exec(ctx.url);
        if (!value) {
            return <ParameterResolutionResult>{
                success: false
            };
        }
        return <ParameterResolutionResult>{
            success: true,
            url: ctx.url.replace(regex, "/"),
            result: value[1]
        };
    }
}

const EXACT_RESOLVER_NAME = "_exact";
export class ExactParameterResolver extends ParameterResolverBase {
    constructor(expectedValue: string) {
        super(EXACT_RESOLVER_NAME);

        this.expectedValue = expectedValue;
    }

    private expectedValue: string;

    public async resolve(ctx: ParameterResolutionContext): Promise<ParameterResolutionResult> {
        let regex = /\/([\w\d_\-]+)(\/)?/;
        let value = regex.exec(ctx.url);
        if (!value || value[1] !== this.expectedValue) {
            return <ParameterResolutionResult>{
                success: false
            };
        }

        return <ParameterResolutionResult>{
            success: true,
            url: ctx.url.replace(regex, "/"),
            result: value[1]
        };
    }
}

const COLON_GROUP_INDEX: number = 1;
const PARAMETER_GROUP_INDEX: number = 2;
const OPTIONAL_GROUP_INDEX: number = 3;

@Dependency.register()
export class ParameterResolverMiddleware {
    static $inject: string[] = ["ParameterResolvers"];
    constructor(resolvers: ParameterResolvers) {
        this.resolvers = resolvers;
        this.resolvers[DEFAULT_RESOLVER_NAME] = new DefaultParameterResolver();
    }

    private resolvers: ParameterResolvers;

    public create(url: string): express.RequestHandler {
        let resolversChain: ResolverChainLink[] = [];

        let match = null;
        //            г--------------- COLON_GROUP_INDEX
        //            |     г--------- PARAMETER_GROUP_INDEX
        //            |     |      г-- OPTIONAL_GROUP_INDEX
        //            v     v      v
        let regex = /(:)?([\w_]+)+(\?)?/g;
        /* tslint:disable:no-conditional-assignment I know what i am doing here */
        while ((match = regex.exec(url)) !== null) {
        /* tslint:enable */
            let name = match[PARAMETER_GROUP_INDEX];
            let isParameter = match[COLON_GROUP_INDEX] === ":";
            let isOptional = match[OPTIONAL_GROUP_INDEX] === "?";
            let resolver: ParameterResolverBase = null;

            if (isParameter && this.resolvers[name]) {
                resolver = this.resolvers[name];
            } else if (isParameter) {
                resolver = this.resolvers[DEFAULT_RESOLVER_NAME];
            } else {
                resolver = new ExactParameterResolver(name);
            }

            resolversChain.push({
                paramName: name,
                resolver: resolver,
                optional: isOptional,
                isParameter: isParameter
            });
        }

        return async (req: express.Request, res: express.Response, next: express.NextFunction): Promise<void> => {
            try {
                let reqUrl = req.url;
                if (reqUrl.includes("?")) {
                    reqUrl = reqUrl.substring(0, reqUrl.indexOf("?"));
                }
                let originalUrl = req.url;

                let resolutionChain: ResolverChainLink[] = [];
                for (let chainLink of resolversChain) {
                    let resolutionLink: ResolverChainLink = {};
                    Object.assign(resolutionLink, chainLink);
                    resolutionLink.resolitionResult = await chainLink.resolver.resolve({
                        url: reqUrl,
                        originalUrl: originalUrl
                    });
                    if (resolutionLink.resolitionResult.error) {
                        return next(resolutionLink.resolitionResult.error);
                    }
                    if (!resolutionLink.resolitionResult.success && !resolutionLink.optional) {
                        return next("route");
                    }
                    reqUrl = resolutionLink.resolitionResult.url;
                    resolutionChain.push(resolutionLink);
                }

                if (reqUrl !== "/") {
                    return next("route");
                }

                for (let link of resolutionChain) {
                    if (!link.isParameter) {
                        continue;
                    }
                    req.params[link.paramName] = link.resolitionResult.result;
                }

                next();
            } catch (error) {
                next(error);
            }
        };
    }
}

export function DiscoverResolvers(container: intravenous.IContainer, searchDir: string): void {
    let files = wrench.readdirSyncRecursive(searchDir);

    let resolvers: string[] = [];
    files.forEach((fileName) => {
        if (path.extname(fileName) !== ".ts") {
            return;
        }
        let jsModuleFile = path.basename(fileName, ".ts");
        let jsModuleFilePath = path.join(searchDir, path.dirname(fileName), `${jsModuleFile}.js`);
        /* tslint:disable:no-require-imports */
        let module: Object = require(jsModuleFilePath);
        /* tslint:enable */
        for (let m in module) {
            if (!module.hasOwnProperty(m)) {
                continue;
            }

            let obj = module[m];
            if (Object.getPrototypeOf(obj) !== ParameterResolverBase) {
                continue;
            }

            container.register(m, module[m], "singleton");
            resolvers.push(m);
        }
    });

    let paramResolvers = resolvers
        .map<ParameterResolverBase>(r => container.get(r))
        .reduce<ParameterResolvers>(
            (r, c) => {
                r[c.name] = c;
                return r;
            },
            <ParameterResolvers>{}
        );

    container.register("ParameterResolvers", paramResolvers, "singleton");
}
