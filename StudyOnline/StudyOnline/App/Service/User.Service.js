/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var app;
(function (app) {
    var services;
    (function (services) {
        ;
        var User = (function () {
            function User() {
            }
            return User;
        })();
        services.User = User;
        var UserService = (function () {
            function UserService($http) {
                this.$http = $http;
            }
            UserService.prototype.getUsers = function () {
                return this.$http.get('http://localhost:22508/study-online/user/')
                    .then(function (response) {
                    return response.data;
                });
            };
            UserService.prototype.addUser = function (User) {
                return this.$http.post('http://localhost:22508/study-online/user/', User)
                    .then(function (response) {
                    return response.data;
                });
            };
            UserService.$inject = ['$http'];
            return UserService;
        })();
        factory.$inject = ['$http'];
        function factory($http) {
            return new UserService($http);
        }
        angular
            .module('myApp')
            .factory('myApp.services.UserService', factory);
    })(services = app.services || (app.services = {}));
})(app || (app = {}));
//# sourceMappingURL=User.Service.js.map