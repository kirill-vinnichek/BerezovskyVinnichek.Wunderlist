var app = angular.module('webApp');

app.controller("taskListFilterCtrl", ['$scope', '$routeSegment', '$location', 'filterService', 'taskService', function ($scope, $routeSegment, $location, filterService, taskService) {

    self = this;
    self.is404 = false
    self.Name = "Отмеченные";
    filterService.getMarked().success(function (data) {
        self.data = data;
        self.is404 = false;
    }).error(function () {
        self.is404 = true;
    });

    var deleteFromList = function (taskList, task) {
        _.remove(taskList.TaskList, function (el) { return el.Id === task.Id });        
        if(--taskList.ItemsCount===0)
            _.remove(self.data, function (el) { return el.Id === taskList.Id });
    };

    self.showDetails = function (taskListId, taskId) {
        $location.url("lists/" + taskListId + "/tasks/" + taskId);
    };

    self.completeTask = function (taskList,task) {
        taskService.completeTask(false, task).success(function (data) {
            deleteFromList(taskList, task);
        });
    };

    self.deleteTask = function (taskList, task) {
        taskService.deleteTask(task.Id).success(function (data) {
            deleteFromList(taskList, task);
        });
    };

    self.unmarkTask = function (taskList, task) {
        taskService.markTask(false,task).success(function (data) {
            deleteFromList(taskList, task);
        });
    };

}]);