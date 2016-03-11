var app = angular.module('webApp');

app.controller("userCtrl", ['$scope','userService', 'close', function ($scope,userService, close) {
    var self = this;

    userService.getUser().then(function (response) {
        $scope.user = response.data;
    });

    $scope.isEmailChangeClick = false;
    $scope.isPasswordChangeClick = false;

}]);