angular.module('onlineExamPrep.pages')
    .directive('oepExamSimulator', function ($q, $state, Constants, Lookups, ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.simulator + 'exam-simulator.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                scope.$root.title = $state.params.examTitle;

                var questionTypes = Lookups.getQuestionTypes();

                ExamService.fullExamQuestions($state.params.id).success(function (data) {
                    vm.questions = _.sortBy(data.questions, function (question) {
                        return question.number;
                    });
                    vm.examLength = data.durationInMinutes * 60;
                });
            }
        };
    });
