var app = angular.module("app", []);

app.controller("appController", ["$scope", "$http", function($scope, $http) {
    console.log("Angular works :D");

    $scope.user = [];

    function getDetails()
    {
        $http.get("/userDetails").success(function(res){
            console.log(res);
            $scope.user = res;
        });
    };

    getDetails();
}]);

