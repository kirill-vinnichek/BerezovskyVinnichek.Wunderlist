var app = angular.module("webApp");

app.service("taskService", ["$http", "$q", function ($http, $q) {

    this.getTasks = function (taskListId) {
        return $http.get("api/itemList/" + taskListId + "/task").success(function (response) {
            return response.data;
        });
    };


    this.createTask = function (task) {
        return $http.post("api/itemList/" + task.ToDoItemListId + "/task", task).success(function (response) {
            return response.data;
        });
    };



}]);