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

                ExamService.getQuestionPreviews($state.params.id).then(function (data) {
                    scope.$root.subtitle = data.examTitle;

                    var list = data.questions;

                    vm.list = list;
                });

                vm.deleteQuestion = function (index) {
                    vm.list.splice(index, 1);
                };

                vm.saveChanges = function () {
                    for (var i = 0; i < vm.list.length; i++) {
                        vm.list[i].number = i + 1;
                    }
                    ExamService.saveQuestionOrder({
                        examQuestions: _.map(vm.list, function (item) { delete item.questionText; item.examId = $state.params.id; return item; }),
                        examId: $state.params.id
                    }).then(function (data) {
                        $state.go('main.exams');
                    });
                };

                function executeQuestionTextWatcher(item, text) {
                    if (text) {
                        item.examDetails.questionText = text;
                    }
                };
            }
        };
    });
