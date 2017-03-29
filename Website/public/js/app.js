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


    $scope.remove = function(id, email){
        console.log(id);
        console.log(email)

        var inputEmail = prompt("Please enter the email address associated with this account to remove it")

        if(inputEmail.toLowerCase() === email)
        {
            $http.delete("/userDetails/" + id).success(function(responce){
                alert("You were successfully removed. Page will now reload.");
                location.reload();
            });
        }
        else {alert("Error, wrong email inputted. Don't try to delete other peoples accounts"); console.log("STOP");}
    };
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