angular.module('onlineExamPrep.components')
    .directive('oepTimer', function ($interval, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'timer.html',
            scope: {
                timeInSeconds: '='
            },
            link: function (scope) {
                var intervalCount = scope.timeInSeconds + 1;
                scope.dangerZone = scope.timeInSeconds / 10;
                $interval(function () {
                    scope.hours = ('0' + Math.floor(scope.timeInSeconds / 3600)).slice(-2);
                    scope.minutes = ('0' + Math.floor((scope.timeInSeconds - (scope.hours * 3600)) / 60)).slice(-2);
                    scope.seconds = ('0' + (scope.timeInSeconds - (scope.hours * 3600 + scope.minutes * 60))).slice(-2);
                    scope.timeInSeconds--;
                    if (scope.timeInSeconds < scope.dangerZone) {
                        scope.displayClass = 'text-danger';
                    }
                }, 1000, intervalCount);
            }
        };
    });
