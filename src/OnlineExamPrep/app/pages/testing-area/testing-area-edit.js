angular.module('onlineExamPrep.pages')
    .directive('oepTestingAreaEdit', function ($state, TestingAreaService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.testingArea + 'testing-area-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.testingArea = {};

                if ($state.params.id) {
                    TestingAreaService.getTestingAreaById($state.params.id).success(function (data) {
                        vm.testingArea = data;
                        vm.showForm = true;
                    });
                }
                else {
                    vm.showForm = true;
                }

                vm.saveTestingArea = function () {
                    if (!scope.testingAreaEditForm.$valid) {
                        return;
                    }

                    TestingAreaService.saveTestingArea(vm.testingArea).success(function () {
                        $state.go('main.testing-areas');
                    });
                }
            }
        };
    });
