var app = angular.module("webApp");

app.service("filterService", ["$http", "$q", function ($http, $q) {

    this.getMarked = function () {
        return $http.get('api/markedFilter');
    };

    this.searchTasks = function (search) {
        return $http.get('api/search/' + search);
    };

}]);