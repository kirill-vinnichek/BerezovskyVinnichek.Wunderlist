var app = angular.module("webApp");

app.service("taskListService", ["$http", "$q", function ($http, $q) {


    this.getTaskLists = function () {
        var p = $http.get('api/itemList').then(function (response) {
            return response;
        });
        return p;
    };

    this.getTaskList = function (id) {

        return $http.get('api/itemList/' + id);
    };

    this.createTaskList = function (itemList) {
        var p = $http.post('api/itemList', itemList).then(function (response) {
            return response;
        });
        return p;
    }

    this.updateTaskList = function (itemList) {
        var p = $http.put('api/itemList', itemList).then(function (response) {
            return response;
        });
        return p;
    }

    this.deleteTaskList = function (id) {
        var p = $http.delete('api/itemList/' + id).then(function (response) {
            return response;
        });
        return p;
    }

    this.updateTasksOrder = function (order) {
        return $http.put('api/order', order);
    };   

}]);