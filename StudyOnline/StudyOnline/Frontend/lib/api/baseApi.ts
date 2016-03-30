import { Injectable, Injector } from "angular2/core";
import { HTTP_PROVIDERS, Http, Request, RequestMethod } from "angular2/http";
import { UrlResolver } from "angular2/compiler";

import { HttpStatusCodes } from "../framework/statusCodes";
import { infrastructureSettings } from "../configuration/infrastructureSettings";


export enum ApiRequestMethod {
    GET,
    POST,
    PUT,
    DELETE
}

export interface RequestParameters {
    method: number;
    body?: Object;
    query?: Object;
    url: string;
    headers?: { [key: string]: string };
}

export interface ApiListResponse<T> {
    count?: number;
    current?: string;
    prev?: string;
    next?: string;
    results: T[];
}

export interface ApiResponse<T> {
    result: T;
}

export interface PagedApiRequest {
    sort?: string|string[];
    limit?: number;
    offset?: number;
}

export interface HttpResponseBase {
    statusCode: number;
    headers: { [name: string]: string };
    request: {
        // uri: url.Url;
        method: string;
        headers: { [name: string]: string };
    };
}

export interface Response<T> extends HttpResponseBase {
    body: T;
}

@Injectable()
export class MyUrlResolver extends UrlResolver {
    resolve(baseUrl: string, url: string): string {
        return super.resolve(baseUrl, url);
    }
}

@Injectable()
class MyRequest {
    constructor(public http: Http) {}
    request(request: RequestParameters) {
      return this.http.request(new Request({
          method: request.method,
          url: request.url
      }));
    }
}


export abstract class BaseApi {
    constructor(requestId: string) {
        this.requestId = requestId;
    }

    protected urlRoot: string;
    protected requestId: string;

    protected post<T>(url: string, body?: Object, query?: Object): Promise<Response<T>> {
        return this.request<T>({
            method: RequestMethod.Post,
            query: query,
            body: body,
            url: url
        });
    }

    protected get<T>(url: string, query?: Object): Promise<Response<T>> {
        return this.request<T>({
            method: RequestMethod.Get,
            query: query,
            url: url
        });
    }

    protected put<T>(url: string, body?: Object, query?: Object): Promise<Response<T>> {
        return this.request<T>({
            method: RequestMethod.Put,
            query: query,
            body: body,
            url: url
        });
    }

    protected delete<T>(url: string, query?: Object): Promise<Response<T>> {
        return this.request<T>({
            method: RequestMethod.Delete,
            query: query,
            url: url
        });
    }

    protected async request<T>(parameters: RequestParameters): Promise<Response<T>> {
        if (!parameters.url) {
            throw new Error("url parameter is required");
        }

        let injectorRequest = Injector.resolveAndCreate([HTTP_PROVIDERS, MyRequest]);
        let myRequest = injectorRequest.get(MyRequest);

        let injectorUrl = Injector.resolveAndCreate([UrlResolver, MyUrlResolver]);
        let urlResolver = injectorUrl.get(injectorUrl);
        let requestUrl = urlResolver(infrastructureSettings.domainApi, parameters.url);

        let dataPromise = null;
        let requestParameters: RequestParameters = null;
        let headers = {
            "X-Request-ID": this.requestId
        };

        if (parameters.query) {
            for (let key in parameters.query) {
                if (!parameters.query.hasOwnProperty(key)) {
                    continue;
                }
                let value = parameters.query[key];
                if (value instanceof Array) {
                    parameters.query[key] = value.join(",");
                }
            }
        }

        switch (parameters.method) {
            case RequestMethod.Get:
                requestParameters = {
                    method: RequestMethod.Get,
                    body: Object,
                    query: parameters.query,
                    url: requestUrl,
                    headers: headers
                };
                break;
            case RequestMethod.Post:
                requestParameters = {
                    method: RequestMethod.Post,
                    body: Object,
                    query: parameters.query,
                    url: requestUrl,
                    headers: headers
                };
                break;
            case RequestMethod.Put:
                requestParameters = {
                    method: RequestMethod.Put,
                    body: Object,
                    query: parameters.query,
                    url: requestUrl,
                    headers: headers
                };
                break;
            case RequestMethod.Delete:
                requestParameters = {
                    method: RequestMethod.Delete,
                    body: Object,
                    query: parameters.query,
                    url: requestUrl,
                    headers: headers
                };
                break;
            default:
                throw new Error(`Method ${parameters.method} is unsupported`);
        }
        dataPromise = myRequest.request(requestParameters);

        try {
            let data = await dataPromise;
            let httpResponse = <Response<T>>data.toJSON();
            return httpResponse;
        } catch (error) {
            if (error.statusCode && (error.statusCode === HttpStatusCodes.NotFound
                || error.statusCode === HttpStatusCodes.Unauthorized)) {
                let httpResponse = <Response<T>>error.response.toJSON();
                httpResponse.body = null;
                return httpResponse;
            }
            let err: any = new Error();
            let innerErr: any = new Error();
            innerErr.message = error.message;
            innerErr.stack = error.stack;
            innerErr["error"] = error.error;

            err.innerError = innerErr;
            throw err;
        }
    }
}
