angular.module('onlineExamPrep.components')
    .directive('oepPublicLayout', function (Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/public/layout.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                vm.user = {
                    login: {
                        userName: 'admin@admin.com',
                        password: 'asd@qwe'
                    },
                    register: {
                        email: null,
                        password: null,
                        confirmPassword: null
                    }
                };

                scope.$watch('$root.title', function () {
                    scope.title = scope.$root.title;
                });

                scope.$watch('$root.subtitle', function () {
                    scope.subtitle = scope.$root.subtitle;
                });

                scope.$watch('$root.loadingContent', function () {
                    scope.loadingContent = scope.$root.loadingContent;
                });
            }
        }
    });
