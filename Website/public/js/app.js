var app = angular.module("app", []);

app.controller("LeaderboardController", ["$scope", "$http", function($scope, $http) {

    $scope.user = [];

    function getDetails()
    {
        $http.get("/userDetails").success(function(res){
            $scope.user = res;

        });
    };

    getDetails();
}]);

app.controller("CreateAccountController", ["$scope", "$http", function ($scope, $http) {

    $scope.createUser = function(){
        console.log($scope.user);
        $scope.user.score = 0;
        $scope.user.timePlayed = 0;

        $http.post("/userDetails", $scope.user).success(function(res){
            alert("Your details have been entered " + $scope.user.username);
            location.reload(true);
        });
    };

    $scope.toggle = function(){
        $scope.createAccount = !$scope.createAccount;
    };
}]);