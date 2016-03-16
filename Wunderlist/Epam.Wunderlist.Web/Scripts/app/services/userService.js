var app = angular.module("webApp");

app.service("userService", ["$http", "$q", function ($http, $q) {
    this.getUser = function () {
        var p = $http.get('api/User').success(function (response) {
            return response;
        });
        return p;
    };

    this.updateUser = function (user) {
        var p = $http.post('api/user',user).success(function (response) {
            return response;
        });
        return p;
    };
}]);