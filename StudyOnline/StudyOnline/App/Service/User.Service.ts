/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.services {
    export interface IUsersService {
        getUsers(): ng.IPromise<User[]>;
        addUser(User: User): ng.IPromise<User>;
    };

    export class User {
        ID: number;
        UserName: string;
        Password: string;
        Name: string;
        Address: string;
        Email: string;
        Phone: string;	
        Avatar: string;
        Status: boolean;
        CreatedDate: string;
        CreatedBy: string;
        ModifiedDate: string;
        ModifiedBy: string;
        GroupID: number;
        PayID: number;
    }

    class UserService implements IUsersService {
        static $inject = ['$http'];
        constructor(private $http: ng.IHttpService) { }

        getUsers(): ng.IPromise<User[]> {
         
            return this.$http.get('http://localhost:22508/study-online/user/')
                .then((response: ng.IHttpPromiseCallbackArg<User[]>): User[]=> {
                   
                    return <User[]>response.data;
                });
        }

        addUser(User: User): ng.IPromise<User> {
            return this.$http.post('http://localhost:22508/study-online/user/', User)
                .then((response: ng.IHttpPromiseCallbackArg<User>): any => {
                    return <User>response.data;
                });
        }
    }

    factory.$inject = ['$http'];
    function factory($http: ng.IHttpService): IUsersService {
        return new UserService($http);
    }

    angular
        .module('myApp')
        .factory('myApp.services.UserService', factory);
}