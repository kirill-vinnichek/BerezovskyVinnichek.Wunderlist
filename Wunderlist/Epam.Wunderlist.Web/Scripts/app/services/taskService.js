var app = angular.module("webApp");

app.service("taskService", ["$http", "$q", function ($http, $q) {
    var self = this;

    this.getTasks = function (taskListId) {
        return $http.get("api/itemList/" + taskListId + "/task");
    };

    this.getTask = function (taskListId, taskId) {
        return $http.get("api/itemList/" + taskListId + "/task/" + taskId);
    };

    this.createTask = function (task) {
        return $http.post("api/itemList/" + task.ToDoItemListId + "/task", task);
    };

    this.updateTask = function (task) {
        return $http.put("api/item/" + task.Id, task);
    };

    this.deleteTask = function (taskId) {
        return $http.delete("api/item/" + taskId);
    };


    this.markTask = function (isMarked, task) {
        task.IsMarked = isMarked;
        return self.updateTask(task);
    }

    this.completeTask = function (isComplete, task) {
        if (isComplete) {
            task.CurrentState = 2;
            task.DateCompleted = new Date();
        }
        else {
            task.CurrentState = 1;
            task.DateCompleted = undefined;
        }
        return self.updateTask(task);
    };

}]);