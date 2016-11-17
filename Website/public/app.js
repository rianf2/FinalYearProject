var app = angular.module("app", []);

app.controller("appCtrl", ["$scope", function($scope){
	console.log("Angular works :D");
	$scope.user = {name: "", password: ""};
	console.log($scope.user.name + $scope.user.password)
}]);

