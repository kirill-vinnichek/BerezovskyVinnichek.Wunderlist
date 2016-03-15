var app = angular.module('webApp');

app.controller("taskListCtrl", ['$scope', '$routeSegment', '$location', 'taskListService', 'taskService', function ($scope, $routeSegment, $location, taskListService, taskService) {

    $scope.showCompleted = false;
    self = this;

    var listId = $routeSegment.$routeParams.listId;
    self.is404 = false;

    var deleteFromList = function (task) {
        if (task.CurrentState === 1)
            _.remove(self.list.unfinishedTasks, function (el) { return el.Id === task.Id });
        else
            _.remove(self.list.completedTasks, function (el) { return el.Id === task.Id });
    };

    var updateOrder = function () {
        var order = {};
        order.Completed = _.map(self.list.completedTasks, 'Id');
        order.Unfinished = _.map(self.list.unfinishedTasks, 'Id');
        taskListService.updateTasksOrder(order);
    };

    taskListService.getTaskList(listId).success(function (data) {
        self.list = data;
        self.is404 = false;
        taskService.getTasks(listId).success(function (data) {
            self.list.completedTasks = data.completedTasks;
            self.list.unfinishedTasks = data.unfinishedTasks;
        });
    }).error(function (http, status, fnc, httpObj) {
        self.is404 = true;
    });

    self.onUnfinishedDropComplete = function (index, data, event) {
        taskService.completeTask(false, data).success(function (task) {
            deleteFromList(data);
            self.list.unfinishedTasks.splice(index, 0, task);
            updateOrder();
        });
    };

    self.onCompletedDropComplete = function (index, data, event) {
        taskService.completeTask(true, data).success(function (task) {
            deleteFromList(data);
            self.list.completedTasks.splice(index, 0, task);
            updateOrder();
        });
    }

    self.onDragComplete = function (data, event) {
        deleteFromList(data);
    }

    self.showDetails = function (taskId) {
        $location.url("lists/" + listId + "/tasks/" + taskId);
    }


    self.addTask = function (taskName) {
        if (taskName.trim() == "") {
            alert("You do not lead a list name! Please specify the field for the list name!");
        }
        else {
            var task = {
                Name: taskName,
                ToDoItemListId: listId,
                NumberInList: self.list.unfinishedTasks.length
            }
            taskService.createTask(task).success(function (data) {
                self.list.unfinishedTasks.push(data);
                $scope.TaskName = "";
            });
        }
    }

    self.deleteTask = function (task) {
        taskService.deleteTask(task.Id).success(function (data) {
            deleteFromList(task);
        });
    };

    self.completeTask = function (isComplete, task) {
        taskService.completeTask(isComplete, task).success(function (data) {
            task = data;
            if (task.CurrentState === 1) {
                _.remove(self.list.completedTasks, function (el) { return el.Id === task.Id });
                self.list.unfinishedTasks.push(task);
            }
            else {
                _.remove(self.list.unfinishedTasks, function (el) { return el.Id === task.Id });
                self.list.completedTasks.push(task);
            }
        });
    }

    self.markTask = function (isMarked, task) {
        taskService.markTask(isMarked, task).success(function (data) {
            task = data;
        });
    };
}]);