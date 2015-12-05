angular.module('onlineExamPrep.pages')
    .directive('oepTestingAreaList', function (TestingAreaService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.testingArea + 'testing-area-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.titleProp = 'title';
                vm.deleteEntity = TestingAreaService.deleteTestingArea;
                vm.getCollection = TestingAreaService.getTestingAreaCollection;

                vm.columns = [
                    { id: 'title', display: 'Naziv' },
                    { id: 'abbreviation', display: 'Skraćenica' }
                ];
            }
        };
    });