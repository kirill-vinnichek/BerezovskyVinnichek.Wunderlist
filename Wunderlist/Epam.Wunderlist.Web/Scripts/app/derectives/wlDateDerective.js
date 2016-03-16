var app = angular.module("webApp");


app.directive('wlDate', function () {
    return {
        link: function (scope, element, attrs) {
            scope.$watch(attrs.wlDate, function (value) {
                if (value) {
                    var locale = attrs.locale;
                    if (!locale)
                        locale = "en-US";
                    var options = {
                        year: 'numeric',
                        month: 'long',
                        day: 'numeric',
                        weekday: 'long',
                    };
                    dateParsed = (new Date(Date.parse(value))).toLocaleString(locale, options);
                    element.text(dateParsed);
                }
            });

        }
    };
});