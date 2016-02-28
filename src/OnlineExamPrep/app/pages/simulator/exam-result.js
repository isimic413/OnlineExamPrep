angular.module('onlineExamPrep.pages')
    .directive('oepExamResult', function ($q, $state, Constants, ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.simulator + 'exam-result.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                scope.$root.title = $state.params.examTitle;
            }
        };
    });
