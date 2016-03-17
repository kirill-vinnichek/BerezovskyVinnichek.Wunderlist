var app = angular.module('webApp');

app.controller("taskCtrl", ['$scope', '$location', '$routeSegment', 'taskService', function ($scope, $location, $routeSegment, taskService) {
    var self = this;
    var taskId = $routeSegment.$routeParams.taskId;
    var listId = $routeSegment.$routeParams.listId;
    self.is404 = false;

    var reload = function () {
        $('body').unbind('click', closeHandler);
        $location.url("lists/" + listId);
        $routeSegment.chain[0].reload();
    };

    //TODO:Подумать еще :)
    var closeHandler = function (event) {
        event.stopPropagation();
        if ($(event.target).parents('.task-details').length == 0) {
            reload();
        }
    }
    $('body').bind('click', closeHandler);

    taskService.getTask(listId, taskId).success(function (data) {
        self.item = data;
        if (self.item.CurrentState === 1)
            self.item.isCompleted = false;
        else
            self.item.isCompleted = true;
        self.item.Date= new Date(Date.parse(self.item.Date));
        self.is404 = false;
    }).error(function (http, status, fnc, httpObj) {
        self.is404 = true;
    });

    self.completeTask = function (isComplete) {
        if (isComplete)
            self.item.CurrentState = 2;
        else
            self.item.CurrentState = 1;
        self.item.isCompleted = isComplete;
    }

    self.markTask = function (isMarked) {
        self.item.IsMarked = isMarked;
    };

    self.close = function () {
        taskService.updateTask(self.item).success(function () {
            reload();
        });
    }

    self.deleteTask = function () {
        taskService.deleteTask(self.item.Id).success(function () {
            reload();
        });
    };

}]);