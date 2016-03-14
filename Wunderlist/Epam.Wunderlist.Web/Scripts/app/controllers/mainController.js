var app = angular.module('webApp');

app.controller("mainCtrl", ["$scope", "$uibModal", "userService", "taskListService", "$log", function ($scope, $uibModal, userService, taskListService, $log) {
    var self = this;

    userService.getUser().then(function (response) {
        $scope.user = response.data;
        taskListService.getTaskLists().then(function (response) {
            $scope.user.taskLists = response.data;
        });
    });


    self.deleteTaskList = function (listId) {
        taskListService.deleteTaskList(listId).then(function() {
            $scope.user.taskLists.splice($scope.user.taskLists.indexOf($scope.user.taskLists.find(el => el.Id === listId)), 1);
        });
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
            //resolve: {
            //    listId: function () {
            //        return id;
            //    }
            //}
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