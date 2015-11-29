angular.module('onlineExamPrep.components')
    .directive('oepPublicLayout', function ($rootScope, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/public/layout.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                scope.$watch(function () { return $rootScope.title; }, function () {
                    scope.title = $rootScope.title;
                });

                scope.$watch(function () { return $rootScope.loadingContent; }, function () {
                    scope.loadingContent = $rootScope.loadingContent;
                });
            }
        }
    });
