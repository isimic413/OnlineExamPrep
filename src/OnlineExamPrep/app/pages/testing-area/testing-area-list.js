angular.module('onlineExamPrep.pages')
    .directive('oepTestingAreaList', function ($uibModal, $state, TestingAreaService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.testingArea + 'testing-area-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.testingAreas = [];
                vm.checkedItem = {};
                vm.alerts = [];
                var alertTemplate = {
                    type: 'success',
                    msg: 'message'
                };
                //vm.alerts.push(alertTemplate);
                //console.log(vm.alerts);

                TestingAreaService.getTestingAreaCollection().success(function (data) {
                    vm.testingAreas = data;
                });

                vm.toggleSelection = function (item) {
                    vm.checkedItem = vm.checkedItem.id === item.id ? {} : item;
                };
                
                vm.gotoEditScreen = function () {
                    $state.go('public.testing-area/edit', { id: vm.checkedItem.id });
                };

                vm.delete = function () {
                    TestingAreaService.deleteTestingArea(vm.checkedItem.id).success(function () {
                        var itemIdx = _.findIndex(vm.testingAreas, function (testingArea) { return testingArea.id === vm.checkedItem.id; });
                        vm.testingAreas.splice(itemIdx, 1);

                        vm.alerts.push(angular.extend(alertTemplate, {
                            msg: 'Obrisano područje ispitivanja "' + vm.checkedItem.title + '".'
                        }));
                    });
                };

                vm.closeAlert = function (index) {
                    vm.alerts.splice(index, 1);
                };
            }
        };
    });