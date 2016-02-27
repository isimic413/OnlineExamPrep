angular.module('onlineExamPrep.pages')
    .directive('oepSimulatorExamList', function ($q, $state, Constants, ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.simulator + 'simulator-exam-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                ExamService.getExamCollection({}).success(function (data) {
                    _.each(data, function (exam) {
                        exam.url = scope.$root.getRouteUrl('main.simulator/exam', { id: exam.id });
                    });
                    vm.exams = data;
                });
            }
        };
    });
