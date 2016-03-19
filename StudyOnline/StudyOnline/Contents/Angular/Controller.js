app.controller("myCtrl", function ($scope, myService) {
    getDocumentCome();
    function getDocumentCome() {
      
        myService.getDocumentCome()
        .success(function (come) {
            $scope.items = come;
            console.log("come", come);
        })
        .error(function (error) {
            $scope.status = 'Unable to load customer data: ' + error;

        });;
    }
});