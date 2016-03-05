angular.module('onlineExamPrep.components')
    .directive('oepHeader', function ($state, Paths, Principal, TokenService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/main/header.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                vm.routes = _.filter($state.get(), function (state) {
                    return state.data && state.data.roles && Principal.isInRoles(state.data.roles);
                });

                scope.logout = function () {
                    Principal.removeCurrent();
                    TokenService.removeToken();
                    $state.go('public.home');
                };
            }
        }
    });
