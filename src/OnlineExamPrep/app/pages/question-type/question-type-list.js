angular.module('onlineExamPrep.pages')
    .directive('oepQuestionTypeList', function (QuestionTypeService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.questionType + 'question-type-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.titleProp = 'title';
                vm.deleteEntity = QuestionTypeService.deleteQuestionType;
                vm.getCollection = QuestionTypeService.getQuestionTypeCollection;

                vm.columns = [
                    { id: 'title', display: 'Naziv' },
                    { id: 'abbreviation', display: 'Skraćenica' }
                ];
            }
        };
    });