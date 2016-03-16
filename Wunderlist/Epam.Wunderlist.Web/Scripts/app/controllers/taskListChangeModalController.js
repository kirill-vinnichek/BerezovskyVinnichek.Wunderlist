var app = angular.module('webApp');

app.controller("taskListChangeModalCtrl", ['$scope', 'taskListService', '$uibModalInstance','toDoList', function ($scope, taskListService, $uibModalInstance, toDoList) {

    self = this;

    self.taskList = { }
    angular.copy(toDoList, self.taskList);

    self.submitChange = function () {
        if (self.taskList.Name.trim() == "") {
            alert("You do not lead a list name! Please specify the field for the list name!");
        }
        else {
            taskListService.updateTaskList(self.taskList).then(function (response) {
                $uibModalInstance.close(response.data);
            })
        }
    };

    self.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);