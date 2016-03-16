var app = angular.module("webApp", [
   'ngRoute',
   'route-segment',
   'view-segment',
   'ngAnimate',
   'ui.bootstrap',
   'ngDraggable',
   'ngFileUpload'
]);

app.config(['$routeSegmentProvider',
    function ($routeSegmentProvider) {
        $routeSegmentProvider.options.autoLoadTemplates = true;
        $routeSegmentProvider.
        when('/lists/:listId', 'lists').
        when('/lists/:listId/tasks/:taskId', 'lists.taskDetails').

        segment('lists', {
            templateUrl: "partials/list.html",
            controller: "taskListCtrl",
            controllerAs: "taskList",
            dependencies: ['listId']
        }).
        within().
        segment('taskDetails', {
            templateUrl: "partials/taskDetails.html",
            controller: "taskCtrl",
            controllerAs: "task",
            dependencies: ['listId', 'taskId']
        });
    }]);


//$routeProvider.
//when('/lists/:listId', {
//    templateUrl: "partials/list.html",
//    controller: "taskListCtrl",
//    controllerAs :"taskList"
//}).
//when("/tasks/:taskId", {
//    templateUrl: "partials/tastDetails.html",
//    controller: "taskCtrl"
//}).
//when('/search', {
//    templateUrl: "partials/search.html",
//    controller: "searchCtrl"
//}).
//otherwise({
//    redirectTo: '/lists/inbox'
//});
