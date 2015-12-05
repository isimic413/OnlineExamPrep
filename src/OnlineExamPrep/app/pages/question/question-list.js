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
                    _.each(vm.entites, function (questionEntity) {
                        questionEntity.hasPictures = questionEntity.questionPictures && questionEntity.questionPictures.length > 0 ? 'Da' : 'Ne';
                        questionEntity.type = questionEntity.questionType.title;
                        questionEntity.testingArea = questionEntity.testingArea.title;
                    });
                }

                vm.columns = [
                    { id: 'text', display: 'Zadatak' },
                    { id: 'hasPictures', display: 'Ima slike' },
                    { id: 'type', display: 'Tip zadatka' },
                    { id: 'testingArea', display: 'Područje ispitivanja' }
                ];
            }
        };
    });