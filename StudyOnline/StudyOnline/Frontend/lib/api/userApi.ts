/* Import section */
import { Dependency } from "../framework/ioc/dependency";
import { BaseApi, ApiListResponse, PagedApiRequest } from "./BaseApi";
import { User} from "./models";

/* Api input parameters section */
export interface GetUserListParameters extends PagedApiRequest {
    location_id?: string;
    usertype_id?: string;
    status_id?: number;
    email?: string;
    user_ids?: string|string[];
}

/* Api interface section */
export interface IUserApi {
    getUserList(parameters?: GetUserListParameters): Promise<ApiListResponse<User>>;
    getUserDetail(userId: string): Promise<User>;
}

/* Api implementation section */
@Dependency.register()
export class UserApi extends BaseApi implements IUserApi {
    static $inject: string[] = ["RequestId"];
    constructor(
        requestId: string
    ) {
        super(
            requestId
        );
    }

    public async getUserList(parameters?: GetUserListParameters): Promise<ApiListResponse<User>> {
        let response = await this.get<ApiListResponse<User>>("/v1/users/", parameters);
        return response.body;
    }

    public async getUserDetail(userId: string): Promise<User> {
        let response = await this.get<User>(`/v1/users/${userId}/`);
        return response.body;
    }
}
