angular.module('onlineExamPrep.components')
    .directive('oepEntityListPage', function ($uibModal, $state, /*QuestionTypeService, */Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'entity-list-page.html',
            scope: {
                vm: '='
            },
            link: function (scope) {
                var vm = scope.vm;

                vm.entities = [];
                vm.checkedItem = {};
                vm.alerts = [];
                var alertTemplate = {
                    type: 'success',
                    msg: 'message'
                };

                var pagingParams = {
                    pageSize: 20,
                    pageNumber: 1
                };

                var entityRoutePrefix = $state.current.params.entityRoutePrefix;
                
                vm.getCollection(pagingParams).success(function (data) {
                    vm.entities = data;
                    if (vm.onDataRecieved) {
                        vm.onDataRecieved();
                    }
                });

                vm.toggleSelection = function (item) {
                    vm.checkedItem = vm.checkedItem.id === item.id ? {} : item;
                    _.each(vm.entities, function (entity) {
                        if (vm.checkedItem.id === entity.id) {
                            entity.isSelected = !entity.isSelected;
                        }
                        else {
                            entity.isSelected = false;
                        }
                    });
                };

                vm.gotoAddScreen = function () {
                    $state.go(entityRoutePrefix + 'add');
                };

                vm.gotoEditScreen = function () {
                    $state.go( entityRoutePrefix + 'edit', { id: vm.checkedItem.id });
                };

                vm.delete = function () {
                    vm.deleteEntity(vm.checkedItem.id).success(function () {
                        var itemIdx = _.findIndex(vm.entities, function (entity) { return entity.id === vm.checkedItem.id; });
                        vm.entities.splice(itemIdx, 1);

                        vm.alerts.push(angular.extend(alertTemplate, {
                            msg: vm.titleProp ? 'Obrisano: ' + vm.checkedItem[vm.titleProp] + '.' : 'Obrisano.'
                        }));
                    });
                };

                vm.closeAlert = function (index) {
                    vm.alerts.splice(index, 1);
                };
            }
        };
    });