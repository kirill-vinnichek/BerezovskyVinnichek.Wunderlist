var app = angular.module('webApp');

app.controller("mainCtrl", ["$scope","ModalService","userService",function ($scope, ModalService,userService) {
    var self = this;

    userService.getUser().then(function (response) {
        $scope.user = response.data;
    });
   




    self.openUserModal = function () {
        ModalService.showModal({
            templateUrl: "partials/userModal.html",
            controller: "userCtrl"
        }).then(function (modal) {

            //it's a bootstrap element, use 'modal' to show it
            modal.element.modal({ backdrop: "static" });
            modal.close.then(function (result) {
                console.log(result);
            });
        });
    };
}]);