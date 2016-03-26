/// <reference path="../../../../typings/curama.d.ts"/>

import * as express from "express";
import * as fs from "fs";
import * as path from "path";
import * as intravenous from "intravenous";

import { Controller } from "./controller";

export function PLCControllers(app: express.Application, controllersDir: string, container: intravenous.IContainer): void {
    let controllers = fs.readdirSync(controllersDir);

    let processedControllers: { name: string, path: string }[] = [];
    controllers.forEach((ctrlFileName) => {
        if (path.extname(ctrlFileName) !== ".js") {
            return;
        }
        /* tslint:disable:no-require-imports */
        let filePath = path.join(controllersDir, ctrlFileName);
        let module: Object = require(filePath);
        /* tslint:enable */
        for (let m in module) {
            if (!module.hasOwnProperty(m)) {
                continue;
            }
            if (!m.endsWith("Controller")) {
                continue;
            }

            let existing = processedControllers.find(c => c.name === m);
            if (existing) {
                console.log(`Duplicate controllers found (${m}) in ${existing.path} and ${filePath}`);
                continue;
            }
            container.register(m, module[m], "perRequest");
            processedControllers.push({
                name: m,
                path: filePath
            });
        }
    });

    processedControllers.forEach((ctrl) => {
        let router = express.Router();
        try {
            let controller = <Controller>container.get(ctrl.name);
            controller._registerController(container, router);
            app.use(router);
        } catch (err) {
            console.error(`Error during ${ctrl.name} registration`, err);
            throw err;
        }
    });

}
