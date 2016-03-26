/// <reference path="../../../../typings/curama.d.ts"/>

import { Dependency } from "../ioc/dependency";
import { IInfrastructureSettings } from "../../configuration/infrastructureSettings";

export interface IStaticResolver {
    js(path?: string): string;
    css(path?: string): string;
    vendor(path?: string): string;
    staticImage(path?: string): string;
}

@Dependency.register({ name: "StaticResolver", env: "development" })
export class StaticResolverDev implements IStaticResolver {
    public js(path?: string): string {
        path = path || "";
        return `/sources/scripts/${path}`;
    }

    public css(path?: string): string {
        path = path || "";
        return `/css/${path}`;
    }

    public vendor(path?: string): string {
        path = path || "";
        return `/sources/bower_components/${path}`;
    }

    public staticImage(path?: string): string {
        path = path || "";
        return `/images/${path}`;
    }
}

@Dependency.register({ name: "StaticResolver", env: "production" })
export class StaticResolver implements IStaticResolver {
    static $inject: string[] = ["InfrastructureSettings"];
    constructor(infrastructureSettings: IInfrastructureSettings) {
        this.infrastructureSettings = infrastructureSettings;
    }

    private infrastructureSettings: IInfrastructureSettings;

    public js(path?: string): string {
        path = path || "";
        let domain = this.infrastructureSettings.frontend.staticDomain;
        return `//${domain}/js/${path}`;
    }

    public css(path?: string): string {
        path = path || "";
        let domain = this.infrastructureSettings.frontend.staticDomain;
        return `//${domain}/css/${path}`;
    }

    public vendor(path?: string): string {
        path = path || "";
        let domain = this.infrastructureSettings.frontend.staticDomain;
        return `//${domain}/vendor/${path}`;
    }

    public staticImage(path?: string): string {
        path = path || "";
        let domain = this.infrastructureSettings.frontend.staticDomain;
        return `//${domain}/images/${path}`;
    }
}
