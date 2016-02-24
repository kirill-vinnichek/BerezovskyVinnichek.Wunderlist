var app = angular.module("app", [
   'ngRoute',
   'controllers'
]);

app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
        when('/phones', {
            templateUrl: "partials/phone-list.html",
            controller: "listController"
        }).
        when("/phones/:phoneId", {
            templateUrl: "partials/phone-details.html",
            controller: "detailsController"
        }).
        otherwise({
            redirectTo: '/phones'
        });
    }]);