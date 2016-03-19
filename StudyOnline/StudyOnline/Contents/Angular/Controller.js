app.controller("myCtrl", function ($scope, myService) {
    GetListCourse();
    function GetListCourse() {
        var getData = myService.GetListCourse();
        getData.then(function (come) {
            $scope.items = come.data;
        });

    }
});