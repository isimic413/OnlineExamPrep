angular.module('onlineExamPrep.pages')
    .directive('oepQuestionEdit', function ($state, QuestionService, Paths, ExamService, QuestionTypeService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.question + 'question-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.showForm = !$state.params.id;
                vm.question = {};

                vm.exams = {
                    model: {}
                };
                vm.questionTypes = {
                    model: {}
                };
                
                ExamService.getExamCollection({}).success(function (data) {
                    vm.exams.data = data;
                });
                QuestionTypeService.getQuestionTypeCollection({}).success(function (data) {
                    vm.questionTypes.data = data;
                });

                vm.saveQuestion = function () {
                    if (!scope.questionForm.$valid) {
                        return;
                    }

                    vm.question.questionTypeId = vm.questionTypes.model.id;

                    var params = {
                        question: vm.question,
                        examId: vm.exams.model.id,
                        answerChoices: vm.answerChoices
                    };

                    QuestionService.saveQuestion(params).success(function () {
                        $state.go('public.questions');
                    });
                };

                //#region Choices

                vm.answerChoices = [];

                vm.addChoice = function (index) {
                    var newChoice = {};
                    vm.answerChoices.splice(index + 1, 0, newChoice);
                };
                vm.addChoice();

                vm.removeChoice = function (index) {
                    vm.answerChoices.splice(index, 1);
                    if (vm.answerChoices.length === 0) {
                        vm.addChoice();
                    }
                };

                //#endregion
            }
        };
    });
