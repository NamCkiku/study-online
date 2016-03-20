/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var Users;
    (function (Users) {
        'use strict';
        var UsersController = (function () {
            function UsersController($http, UserService) {
                this.$http = $http;
                this.UserService = UserService;
                this.showUser = false;
                this.getUsers();
            }
            UsersController.prototype.showUserForm = function (show) {
                this.showUser = show;
            };
            UsersController.prototype.addUser = function (newUser) {
                var _this = this;
                return this.UserService.addUser(newUser)
                    .then(function (data) {
                    _this.showUser = false;
                    _this.newUser = {};
                    _this.Users.push(data);
                });
            };
            UsersController.prototype.getUsers = function () {
                var _this = this;
                return this.UserService.getUsers()
                    .then(function (data) {
                    return _this.Users = data;
                });
            };
            UsersController.$inject = ['$http', 'myApp.services.UserService'];
            return UsersController;
        })();
        angular
            .module('myApp')
            .controller('myApp.Users.UsersController', UsersController);
    })(Users = app.Users || (app.Users = {}));
})(app || (app = {}));
//# sourceMappingURL=Users.Controller.js.map