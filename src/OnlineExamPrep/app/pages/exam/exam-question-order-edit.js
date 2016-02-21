angular.module('onlineExamPrep.pages')
    .directive('oepExamQuestionOrderEdit', function ($state, ExamService, Paths, QuestionService) {
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
                    scope.$root.subtitle = data.examTitle;

                    var list = _.map(data.questions, function (item) {
                        return {
                            examDetails: item
                        };
                    });

                    _.each(list, function (item) {
                        item.deregisterWatcher = scope.$watch(function () {
                            if (item.question && item.question.text) {
                                return item.question.text;
                            }
                        },
                        function (newValue) {
                            executeQuestionTextWatcher(item, newValue);
                        });
                    });

                    vm.list = list;
                });

                vm.editQuestion = function (item) {
                    if (item.isOpen) {
                        item.isOpen = false;
                        return;
                    }

                    if (!item.question.id && item.examDetails.questionId) {
                        QuestionService.getQuestion(item.examDetails.questionId).success(function (data) {
                            item.question = data;
                            item.question.questionType.id = data.questionTypeId;
                            item.isOpen = true;
                        });
                    }
                    else {
                        item.isOpen = true;
                    }
                }

                vm.addQuestion = function () {
                    var item = {
                        examDetails: {
                            examId: $state.params.id
                        },
                        isOpen: true
                    };

                    item.deregisterWatcher = scope.$watch(function () {
                        if (item.question && item.question.text) {
                            return item.question.text;
                        }
                    },
                    function (newValue) {
                        executeQuestionTextWatcher(item, newValue);
                    });

                    vm.list.push(item);
                };

                vm.deleteQuestion = function (index) {
                    vm.list[index].deregisterWatcher();
                    vm.list.splice(index, 1);
                };

                vm.saveChanges = function () {
                    for (var i = 0; i < vm.questions.list.length; i++) {
                        vm.questions.list[i].number = i + 1;
                    }
                    ExamService.saveQuestionOrder({
                        examQuestions: vm.list,
                        examId: $state.params.id
                    }).success(function (data) {
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
