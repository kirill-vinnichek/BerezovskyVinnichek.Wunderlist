var app = angular.module("webApp");

app.service("uploadService", ["$http", "$q","Upload", function ($http, $q,Upload) {
    

    this.uploadImage = function (file) {
        return Upload.upload({
            url: 'api/image',
            headers: {
                'Content-Type': file.type
            },
            data: { file: file }
        });
    };

}]);