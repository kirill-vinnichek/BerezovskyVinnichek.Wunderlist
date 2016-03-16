var app = angular.module("webApp", [
   'ngRoute',
   'route-segment',
   'view-segment',
   'ngAnimate',
   'ui.bootstrap',
   'ngDraggable',
   'ngFileUpload'
]);

app.config(['$routeSegmentProvider', '$routeProvider',
    function ($routeSegmentProvider, $routeProvider) {
        $routeSegmentProvider.options.autoLoadTemplates = true;
        $routeSegmentProvider.
        when('/search/:searchString', 'search').
        when('/filter/:filterName', 'filter').
        when('/lists/:listId', 'lists').
        when('/lists/:listId/tasks/:taskId', 'lists.taskDetails');

        $routeSegmentProvider.
            segment('filter', {
                templateUrl: "partials/markedList.html",
                controller: "taskListFilterCtrl",
                controllerAs: "ctrl",
                dependencies: ['filterName']
            });;

        $routeSegmentProvider.
           segment('search', {
               templateUrl: "partials/markedList.html",
               controller: "searchCtrl",
               controllerAs: "ctrl",
               dependencies: ['searchString']
           });;

        $routeSegmentProvider.
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

        $routeProvider.otherwise({ redirectTo: 'filter/marked' });
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
