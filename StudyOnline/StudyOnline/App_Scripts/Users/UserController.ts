/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.users {
    "User StudyOnline";
    interface IUserScope {
        Users: User[];
        newUser: User;
        showUser: Boolean;
        getUsers(): ng.IPromise<User[]>;
        addUser(showUser: Boolean): ng.IPromise<User>;
        showUserForm(): void;
    }

    class User {
        id: string;
        name: string;
        pass: string;
        status: Boolean;
    }

    class UserController implements IUserScope {
        Users: User[];
        newUser: User;
        showUser: Boolean;
        static $inject = ['http'];
        constructor(private $http: ng.IHttpBackendService) {
            this.getUsers();
            this.showUser = false;
        }
        getUsers(): ng.IPromise<User[]> { throw new Error("LOL") }
        addUser(showUser: Boolean): ng.IPromise<User> { throw new Error("LOL") }
        showUserForm(): void { }

    }
    angular.module("myApp").controller("app.users.UserController", UserController);
}