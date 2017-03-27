var bug_app = angular.module("bug_app", []);

bug_app.controller("BugController", ["$scope", "$http", function ($scope, $http) {
    console.log("Using BugController");

    $scope.report = function(){
        $scope.user.dateReported = getCurrentDate();

        $http.post("/bugReports", $scope.user).success(function(res){
            alert("The bug has been reported, thank you!");
            location.reload();
        });
    };
}]);

function getCurrentDate()
{
    var today = new Date();
    var days = today.getDate();
    var month = today.getMonth() + 1; // Starts at 0
    var year = today.getFullYear();
    var hours = today.getHours();
    var minutes = today.getMinutes();
    var seconds = today.getSeconds();

    if(days < 10) { days = "0" + days; }
    if(month < 10) { month = "0" + month; }
    if(minutes < 10) { minutes = "0" + minutes; }
    if(seconds < 10) { seconds = "0" + seconds; }

    today = days + "/" + month + "/" + year + " " + hours + ":" + minutes + ":" + seconds;
    return today;
}
