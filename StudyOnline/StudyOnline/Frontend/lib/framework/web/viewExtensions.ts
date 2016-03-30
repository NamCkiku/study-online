/// <reference path="../../../../typings/curama.d.ts"/>

import * as intravenous from "intravenous";
import * as express from "express";
import * as nunjucks from "nunjucks";

export class AwaitExtension {
    tags: string[] = ["await"];

    public parse(parser, nodes, lexer): any {
        let tok = parser.nextToken();
        let args = parser.parseSignature(null, true);
        parser.advanceAfterBlockEnd(tok.value);

        return new nodes.CallExtensionAsync(this, "run", args, []);
    }

    public run(context, asyncResult, callback: Function): void {
        try {
            if (asyncResult.then) {
                (<Promise<any>>asyncResult).then(
                    result => {
                        try {
                            callback(null, result);
                        } catch (error) {
                            console.log(error.stack);
                            callback(error.stack);
                        }
                    },
                    err => {
                        callback(err.stack);
                    }
                );
            } else {
                callback(null, asyncResult);
            }
        } catch (error) {
            callback(error);
        }
    }
}

export class PartialViewExtension {
    tags: string[] = ["partial"];

    constructor(container: intravenous.IContainer, env: nunjucks.IEnvironment) {
        this.container = container;
        this.env = env;
    }
    private container: intravenous.IContainer;
    private env: nunjucks.IEnvironment;

    public parse(parser, nodes, lexer): any {
        let tok = parser.nextToken();
        let args = parser.parseSignature(null, true);
        parser.advanceAfterBlockEnd(tok.value);

        return new nodes.CallExtensionAsync(this, "run", args, []);
    }

    public run(context, request: express.Request, response: express.Response, controller: string, action: string, partialModelOrCallback: Object|Function, callback: Function): void {
        let partialModel: Object = null;
        if (typeof partialModelOrCallback === "function") {
            callback = <Function>partialModelOrCallback;
        } else {
            partialModel = <Object>partialModelOrCallback;
        }

        let ctrl = this.container.get(`${controller}Controller`);
        let handler = ctrl[action].bind(ctrl);

        let promise: Promise<string> = null;
        try {
            promise = <Promise<string>>handler(request, response, this.env, partialModel);
        } catch (error) {
            callback(error);
        }

        if (!promise.then) {
            throw new RangeError(`Partial view must return promise! ${controller}Controller.${action}`);
        }
        promise.then(content => {
            let result = new nunjucks.runtime.SafeString(content);
            try {
                callback(null, result);
            } catch (error) {
                callback(error);
            }
        }).catch(error => {
            callback(error);
        });
    }
}
