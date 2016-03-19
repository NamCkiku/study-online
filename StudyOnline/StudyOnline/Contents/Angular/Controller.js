app.controller("myCtrl", function ($scope, myService) {
    getDocumentCome();
    function getDocumentCome() {
        alert(1);
        myService.getDocumentCome()
        .success(function (come) {
            $scope.items = come.data;
            console.log("come", come);
        })
        .error(function (error) {
            $scope.status = 'Unable to load customer data: ' + error;

        });;
    }
});