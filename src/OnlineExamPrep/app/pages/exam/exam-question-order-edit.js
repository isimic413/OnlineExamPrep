angular.module('onlineExamPrep.pages')
    .directive('oepExamQuestionOrderEdit', function ($state, ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.exam + 'exam-question-order-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                ExamService.getQuestionPreviews($state.params.id).success(function (data) {
                    vm.questions = {
                        list: data.questions
                    };
                    scope.$root.subtitle = data.examTitle;
                });

                vm.saveChanges = function () {
                    for (var i = 0; i < vm.questions.list.length; i++) {
                        vm.questions.list[i].number = i + 1;
                    }
                    ExamService.saveQuestionOrder({
                        examQuestions: vm.questions.list,
                        examId: $state.params.id
                    }).success(function (data) {
                        $state.go('public.exams');
                    });
                };
            }
        };
    });