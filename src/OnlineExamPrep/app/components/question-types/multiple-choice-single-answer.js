angular.module('onlineExamPrep.components')
    .directive('oepMultipleChoiceSingleAnswer', function ($state, $window, Paths, QuestionService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'question-types/multiple-choice-single-answer.html',
            scope: {
                vm: '=',
                enableAnswer: '=',
                separatedChoices: '=',
                choices: '='
            },
            link: function (scope) {
                var vm = scope.vm;

                if (scope.separatedChoices) {
                    vm.choices = scope.choices;
                }
            }
        };
    });
