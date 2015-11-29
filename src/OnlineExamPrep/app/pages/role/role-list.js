angular.module('onlineExamPrep.pages')
    .directive('oepRoleList', function ($uibModal, $state, RoleService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.role + 'role-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.roles = [];
                vm.checkedItem = {};
                vm.alerts = [];
                var alertTemplate = {
                    type: 'success',
                    msg: 'message'
                };
                //vm.alerts.push(alertTemplate);
                //console.log(vm.alerts);

                RoleService.getRoleCollection().success(function (data) {
                    vm.roles = data;
                });

                vm.toggleSelection = function (item) {
                    vm.checkedItem = vm.checkedItem.id === item.id ? {} : item;
                };

                vm.gotoEditScreen = function () {
                    $state.go('public.role/edit', { id: vm.checkedItem.id });
                };

                vm.delete = function () {
                    RoleService.deleteRole(vm.checkedItem.id).success(function () {
                        var itemIdx = _.findIndex(vm.roles, function (role) { return role.id === vm.checkedItem.id; });
                        vm.roles.splice(itemIdx, 1);

                        vm.alerts.push(angular.extend(alertTemplate, {
                            msg: 'Obrisan tip korisnika: "' + vm.checkedItem.name + '".'
                        }));
                    });
                };

                vm.closeAlert = function (index) {
                    vm.alerts.splice(index, 1);
                };
            }
        };
    });