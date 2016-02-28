angular.module('onlineExamPrep.components')
    .directive('oepAlternativeAnswer', function ($state, $window, Paths, QuestionService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'question-types/alternative-answer.html',
            scope: {
                vm: '=',
                enableAnswer: '='
            },
            link: function (scope) {
                var vm = scope.vm;
            }
        };
    });
