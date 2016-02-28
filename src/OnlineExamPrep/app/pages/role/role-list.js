angular.module('onlineExamPrep.pages')
    .directive('oepRoleList', function (RoleService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.role + 'role-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.titleProp = 'title';
                vm.deleteEntity = RoleService.deleteRole;
                vm.getCollection = RoleService.getRoleCollection;

                vm.columns = [
                    { id: 'name', display: 'Naziv' }
                ];
            }
        };
    });