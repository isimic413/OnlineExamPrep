angular.module('onlineExamPrep.pages')
    .directive('oepRoleEdit', function ($state, RoleService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.role + 'role-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.role = {};

                if ($state.params.id) {
                    RoleService.getRoleById($state.params.id).then(function (data) {
                        vm.role = data;
                        vm.showForm = true;
                    });
                }
                else {
                    vm.showForm = true;
                }

                vm.saveRole = function () {
                    if (!scope.roleEditForm.$valid) {
                        return;
                    }

                    RoleService.saveRole(vm.role).then(function () {
                        $state.go('main.roles');
                    });
                }
            }
        };
    });