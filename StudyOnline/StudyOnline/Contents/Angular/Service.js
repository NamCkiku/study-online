app.service("myService", ['$http', function ($http) {
    var myService = {};

    myService.getDocumentCome = function () {
        return $http.get("http://localhost:22508/study-online/user/");
    };

    return myService;
}]);