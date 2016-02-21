angular.module('onlineExamPrep.components')
    .directive('oepMainLayout', function ($state, Paths, Principal) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/main/layout.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                scope.$watch('$root.title', function () {
                    scope.title = scope.$root.title;
                });

                scope.$watch('$root.subtitle', function () {
                    scope.subtitle = scope.$root.subtitle;
                });

                scope.$watch('$root.loadingContent', function () {
                    scope.loadingContent = scope.$root.loadingContent;
                });

                scope.logout = function () {
                    Principal.removeCurrent();
                    $state.go('public.home');
                };
            }
        }
    });
