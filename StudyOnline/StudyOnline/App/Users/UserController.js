/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var users;
    (function (users) {
        "User StudyOnline";
        var User = (function () {
            function User() {
            }
            return User;
        })();
        var UserController = (function () {
            function UserController($http) {
                this.$http = $http;
                this.getUsers();
                this.showUser = false;
            }
            UserController.prototype.getUsers = function () { throw new Error("LOL"); };
            UserController.prototype.addUser = function (showUser) { throw new Error("LOL"); };
            UserController.prototype.showUserForm = function () { };
            UserController.$inject = ['http'];
            return UserController;
        })();
        angular.module("myApp").controller("app.users.UserController", UserController);
    })(users = app.users || (app.users = {}));
})(app || (app = {}));
//# sourceMappingURL=UserController.js.map