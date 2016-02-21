angular.module('onlineExamPrep.pages')
    .directive('oepQuestionEdit', function (Paths, Lookups) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.question + 'question-edit.html',
            scope: {
                question: '='
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.questionTypes = {
                    model: {},
                    data: _.filter(Lookups.getQuestionTypes(), function (type) { return type; })
                };

                if (!scope.question) {
                    scope.question = {
                        answerChoices: [],
                        questionType: {}
                    };
                }

                vm.addChoice = function (index) {
                    var newChoice = {
                        points: 0
                    };
                    scope.question.answerChoices.splice(index + 1, 0, newChoice);
                };
                vm.addChoice();

                vm.removeChoice = function (index) {
                    scope.question.answerChoices.splice(index, 1);
                    if (scope.question.answerChoices.length === 0) {
                        vm.addChoice();
                    }
                };
            }
        };
    });
