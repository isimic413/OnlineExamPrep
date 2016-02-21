angular.module('onlineExamPrep.components')
    .directive('oepHeader', function ($state, Paths, Principal) {
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
            }
        }
    });
