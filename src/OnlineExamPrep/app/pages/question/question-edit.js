angular.module('onlineExamPrep.pages')
    .directive('oepQuestionEdit', function ($state, QuestionService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.question + 'question-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
            }
        };
    });