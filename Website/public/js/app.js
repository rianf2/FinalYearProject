var app = angular.module("app", []);

app.controller("LeaderboardController", ["$scope", "$http", function($scope, $http) {
    console.log("Using LeaderboardController");

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

app.controller("CreateAccountController", ["$scope", "$http", function ($scope, $http) {
    console.log("Using CreateAccountController");

    $scope.createUser = function(){
        console.log($scope.user);
        $scope.user.highscore = 0;
        $scope.user.highestLevel = 0;
        $scope.user.timeplayed = 0;

        $http.post("/userDetails", $scope.user).success(function(res){
            console.log(res);
            alert("Your details have been entered " + $scope.user.username);
            location.reload(true);
        });
    };

    $scope.toggle = function(){
        $scope.createAccount = !$scope.createAccount;
    };
}]);

app.controller("LoginController", ["$scope", "$http", function($scope, $http){
    console.log("Using LoginController");

    var username = "";
    var password = "";

    $scope.login = function(){
        console.log("Logging in I guess");
        username = $scope.user.username;
        password = $scope.user.password;

        console.log("Username: " + username);
        console.log("Password: " + password);

        $http.get("/userDetails/" + username).success(function(res){
            console.log(res);
            $scope.user = res;
        });
    };

    $scope.showLogin = function(){
        $scope.loginDetails = !$scope.loginDetails;
    };
}]);