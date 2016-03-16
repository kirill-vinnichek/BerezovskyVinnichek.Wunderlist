var app = angular.module('webApp');

app.controller("mainCtrl", ["$scope", "$uibModal", "userService", "taskListService", "taskService", '$location', "$log", function ($scope, $uibModal, userService, taskListService, taskService, $location, $log) {
    var self = this;
    self.searchString = "";

    userService.getUser().then(function (response) {
        $scope.user = response.data;
        taskListService.getTaskLists().then(function (response) {
            $scope.user.taskLists = response.data;
        });
    });

    self.deleteTaskList = function (listId) {
        taskListService.deleteTaskList(listId).then(function () {
            _.remove($scope.user.taskLists, function (el) {
                return el.Id === listId
            });
        });
    }

    self.onDropComplete = function (index, data, event) {
        data.ToDoItemListId = $scope.user.taskLists[index].Id;
        taskService.updateTask(data).success(function (task) {
            data = task;
        });
    }

    self.showSearch = function (search) {
        $location.url("search/" + search);
    }

    self.canselSearch = function () {
        self.searchString = "";
        $location.url("");
    }


    self.openUserModal = function () {
        var userModal = $uibModal.open({
            animation: true,
            templateUrl: 'partials/modals/userModa.html',
            controller: 'userCtrl',
            controllerAs: 'userModal',
            scope: $scope,
            backdrop: 'static',
            size: "lg",
            appendTo: $(".wrapper"),
        });

        userModal.result.then(function (mess) {
            $log.info(mess);
        }, function (mess) {
            $log.info(mess);
        });

    };

    self.openCreateListModal = function (id) {
        var createListModal = $uibModal.open({
            animation: true,
            templateUrl: 'partials/modals/createListModal.html',
            controller: 'taskListCreateModalCtrl',
            controllerAs: 'taskList',
            backdrop: 'static',
            scope: $scope,
            appendTo: $(".wrapper"),
        });

        createListModal.result.then(function (TaskList) {
            $scope.user.taskLists.push(TaskList);
        });
    };

    self.openChangeListModal = function (list) {
        var changeListModal = $uibModal.open({
            animation: true,
            templateUrl: 'partials/modals/changeListModal.html',
            controller: 'taskListChangeModalCtrl',
            controllerAs: 'taskList',
            backdrop: 'static',
            scope: $scope,
            appendTo: $(".wrapper"),
            resolve: {
                toDoList: function () {
                    return list;
                }
            }
        });

        changeListModal.result.then(function (TaskList) {
            //Если менять сам объект - вьюшка не обновляется
            list.Name = TaskList.Name;
            //$scope.$apply();
        });
    };


}]);