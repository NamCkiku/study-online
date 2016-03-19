app.service("myService", function ($http) {
    this.getListCourse = function () {
        return $http.get("/Home/GetListCouse");
    }

    this.getDocumentCome = function () {
        return $http.get("/Home/GetListCouse");
    };

});