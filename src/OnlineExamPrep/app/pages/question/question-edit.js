﻿angular.module('onlineExamPrep.pages')
    .directive('oepQuestionEdit', function ($q, $state, QuestionService, Paths, ExamService, QuestionTypeService, Lookups) {
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
                vm.questionTypes = Lookups.getQuestionTypes();
                vm.questionTypes.data = _.map(vm.questionTypes, function (type) {
                    return type;
                });
                vm.questionTypes.model = {};

                if ($state.params.id) {
                    $q.all([
                        ExamService.getExamCollection({}),
                        QuestionService.getQuestion($state.params.id)
                    ]).then(function (results) {
                        bindData(results[0].data, results[1].data);
                    });
                }
                else {
                    ExamService.getExamCollection({}).success(function (data) {
                        bindData(data);
                    });
                }

                function bindData(examData, questionData) {
                    vm.exams.data = examData;
                    if (questionData) {
                        vm.question = questionData;
                        vm.exams.model = { id: questionData.examQuestions[0].examId };
                        vm.questionTypes.model = { id: questionData.questionType.id };
                        vm.answerChoices = questionData.answerChoices;
                        vm.question.choices = vm.answerChoices;
                    }
                    vm.showForm = true;
                }

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
                        $state.go('main.questions');
                    });
                };

                //#region Choices

                vm.answerChoices = [];
                vm.question.choices = angular.extend(vm.answerChoices);

                vm.addChoice = function (index) {
                    var newChoice = {
                        points: 0
                    };
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