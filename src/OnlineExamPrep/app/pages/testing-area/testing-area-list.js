angular.module('onlineExamPrep.pages')
    .directive('oepTestingAreaList', function ($state, TestingAreaService, Paths) {
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

                TestingAreaService.getTestingAreaCollection().success(function (data) {
                    vm.testingAreas = data;
                });

                vm.toggleSelection = function (item) {
                    vm.checkedItem = vm.checkedItem.id === item.id ? {} : item;
                    vm.editRoute = vm.checkedItem ? $state.href('public.testing-area/edit') + vm.checkedItem.id : null;
                };
                
                vm.gotoEditScreen = function () {
                    $state.go('public.testing-area/edit', { id: vm.checkedItem.id });
                };

                vm.delete = function () {
                    //TestingAreaService
                };
            }
        };
    });