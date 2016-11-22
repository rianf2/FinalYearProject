var app = angular.module("app", []);

app.controller("appCtrl", ["$scope", function($scope){
	console.log("Angular works :D");
	$scope.user = {name: "", password: ""};

    $scope.buttonClicked = function(name, password)
    {
        console.log("Logging in " + $scope.user.name + " with " + $scope.user.password)
    }
}]);

