var app = angular.module("app", []);

app.controller("appController", ["$scope", function($scope){
	console.log("Angular works :D");

	$scope.user = [];

	$scope.user.push({
					  name: "Rian",
		highscore: 420,
		timeplayed: 60
	});

    $scope.user.push({
        name: "Rebecca",
        highscore: 1000,
        timeplayed: 420
    });

    $scope.user.push({
        name: "Cian",
        highscore: 0,
        timeplayed: 100
    });

    $scope.user.push({
        name: "Shane",
        highscore: -99999999,
        timeplayed: 50

    });

    $scope.user.push({
        name: "Rowan",
        highscore: 720,
        timeplayed: 69
    });

    $scope.user.push({
        name: "Mark",
        highscore: 100,
        timeplayed: 90
    });

    $scope.user.push({
        name: "Andrew",
        highscore: 0,
        timeplayed: 900
    });
}]);

