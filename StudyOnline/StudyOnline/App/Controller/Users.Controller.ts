/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
module app.Users {
    'use strict';

    import User = app.services.User;

    interface IUserScope {
        getUsers(): ng.IPromise<User[]>;
        showUserForm(show: Boolean): void;
        Users: User[];
        showUser: Boolean;
        addUser(newUser: User): ng.IPromise<User>;
        newUser: User;
    }

    class UsersController implements IUserScope {
        Users: User[];
        showUser: Boolean;
        newUser: User;

        static $inject = ['$http', 'myApp.services.UserService'];
        constructor(private $http: ng.IHttpService, public UserService: services.IUsersService) {
            this.showUser = false;
            this.getUsers();
        }

        showUserForm(show: Boolean): void {
            this.showUser = show;
        }

        addUser(newUser: User): ng.IPromise<User> {
            return this.UserService.addUser(newUser)
                .then((data: ng.IHttpPromiseCallbackArg<User>): any => {
                    this.showUser = false;
                    this.newUser = <any>{};
                    this.Users.push(<User>data);
                });
        }

        getUsers(): ng.IPromise<User[]> {
            return this.UserService.getUsers()
                .then((data: ng.IHttpPromiseCallbackArg<User[]>): any => {
                    return this.Users = <User[]>data;
                });
        }
    }

    angular
        .module('myApp')
        .controller('myApp.Users.UsersController', UsersController);

} 