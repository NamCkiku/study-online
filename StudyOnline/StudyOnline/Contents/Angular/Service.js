app.service("myService", function ($http) {
    this.GetListCourse = function () {
        return $http.get("/Home/GetListCouse");
    }


});