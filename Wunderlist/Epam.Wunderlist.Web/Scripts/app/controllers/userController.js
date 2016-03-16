var app = angular.module('webApp');

app.controller("userCtrl", ['$scope', '$uibModalInstance', 'userService', 'uploadService', function ($scope, $uibModalInstance, userService, uploadService) {
    var self = this;
    self.user = {};
    angular.copy($scope.user, self.user);

    $scope.isEmailChangeClick = false;
    $scope.isPasswordChangeClick = false;


    self.changeUserName = function () {
        userService.updateUser(self.user).then(function (response) {
            $scope.user.UserName = self.user.UserName;
        })
    };

    self.uploadFiles = function (file) {
        if (file) {
            uploadService.uploadImage(file).then(function (resp) {
                console.log('Success ' + resp.data.mess);
                self.user.UserPhotoUrl = resp.data.url;
                $scope.user.UserPhotoUrl = self.user.UserPhotoUrl;
            }, function (resp) {
                console.log('Error status: ' + resp.status);
            }, function (evt) {
                var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
            });
        }
    }

    self.ok = function () {
        $uibModalInstance.close("ok");
    };

    self.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

}]);