angular.module('onlineExamPrep.pages')
    .directive('oepQuestionList', function (QuestionService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.question + 'question-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.titleProp = 'title';
                vm.deleteEntity = QuestionService.deleteQuestion;
                vm.getCollection = QuestionService.getQuestionCollection;

                vm.onDataRecieved = function () {
                    //
                }

                vm.columns = [
                    { id: 'textPreview', display: 'Zadatak' },
                    { id: 'area', display: 'Područje ispitivanja' },
                    { id: 'term', display: 'Ispitni rok' },
                    { id: 'points', display: 'Broj bodova' },
                    { id: 'questionType', display: 'Tip zadatka' }
                ];
            }
        };
    });
