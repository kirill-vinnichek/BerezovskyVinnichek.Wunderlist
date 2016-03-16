var app = angular.module("webApp");

app.service("filterService", ["$http", "$q", function ($http, $q) {

    this.getMarked = function () {
        return $http.get('api/markedFilter');
    };

}]);