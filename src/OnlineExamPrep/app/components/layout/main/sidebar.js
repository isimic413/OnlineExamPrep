angular.module('onlineExamPrep.components')
    .directive('oepSidebar', function ($state, Paths, Principal, TokenService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/main/sidebar.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                var routes = _.filter($state.get(), function (state) {
                    return state.data && state.data.roles && Principal.isInRoles(state.data.roles);
                });

                scope.$root.routes = {};
                _.each(routes, function (route) {
                    scope.$root.routes[route.name] = route;
                });

                scope.logout = function () {
                    Principal.removeCurrent();
                    TokenService.removeToken();
                    $state.go('public.home');
                };
            }
        }
    });
