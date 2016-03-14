var app = angular.module("webApp", [
   'ngRoute',
   'ngAnimate',
   'ui.bootstrap',
   'ngFileUpload'
]);

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
        when('/lists/:listId', {
            templateUrl: "partials/list.html",
            controller: "taskListCtrl",
            controllerAs :"taskList"
        }).
        when("/tasks/:taskId", {
            templateUrl: "partials/tastDetails.html",
            controller: "taskCtrl"
        }).
        when('/search', {
            templateUrl: "partials/search.html",
            controller: "searchCtrl"
        }).
        otherwise({
            redirectTo: '/lists/inbox'
        });
    }]);