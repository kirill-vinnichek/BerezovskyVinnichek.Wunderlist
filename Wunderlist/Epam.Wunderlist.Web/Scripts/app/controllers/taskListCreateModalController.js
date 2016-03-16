var app = angular.module('webApp');

app.controller("taskListCreateModalCtrl", ['$scope', 'taskListService', '$uibModalInstance', function ($scope, taskListService, $uibModalInstance) {

    self = this;

    self.taskList = {
        Name: "",
        ItemsCount: ""
    }

    self.createTaskList = function () {
        if (self.taskList.Name.trim() == "") {
            alert("You do not lead a list name! Please specify the field for the list name!");
        }
        else {
            taskListService.createTaskList(self.taskList).then(function (response) {
                $uibModalInstance.close(response.data);
            })
        }
    };

    self.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);