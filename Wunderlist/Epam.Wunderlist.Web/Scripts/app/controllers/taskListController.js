var app = angular.module('webApp');

app.controller("taskListCtrl", ['$scope', '$routeParams', 'taskListService', 'taskService', function ($scope, $routeParams, taskListService, taskService) {
    self = this;

    var listId = $routeParams.listId;
    self.is404 = false;

    taskListService.getTaskList(listId).success(function (data) {
        self.list = data;
        self.is404 = false;
        taskService.getTasks(listId).success(function (data) {
            self.list.complitedTasks = data.completedTasks;
            self.list.unfinishedTasks = data.unfinishedTasks;
        });
    }).error(function (http, status, fnc, httpObj) {
        self.is404 = true;
    });

    self.addTask = function (taskName) {
        if (taskName.trim() == "") {
            alert("You do not lead a list name! Please specify the field for the list name!");
        }
        else {
            var task = {
                Name: taskName,
                ToDoItemListId: listId
            }
            taskService.createTask(task).success(function (data) {
                self.list.unfinishedTasks.push(data);
                $scope.TaskName = "";
            });

        }
    }

}]);