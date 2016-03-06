angular.module('onlineExamPrep.components')
    .directive('oepLongAnswer', function ($state, $window, Paths, QuestionService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'question-types/long-answer.html',
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
