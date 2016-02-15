angular.module('onlineExamPrep.pages')
    .directive('oepExamList', function (ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.exam + 'exam-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.titleProp = 'title';
                vm.deleteEntity = ExamService.deleteExam;
                vm.getCollection = ExamService.getExamCollection;

                vm.onDataRecieved = function () {
                    _.each(vm.entities, function (examEntity) {
                        var hours = parseInt(examEntity.durationInMinutes / 60, 10);
                        examEntity.displayDuration = hours + ':' + (examEntity.durationInMinutes - 60*hours);
                    });
                }

                vm.columns = [
                    { id: 'title', display: 'Ispit' },
                    { id: 'numberOfQuestions', display: 'Broj zadataka' },
                    { id: 'displayDuration', display: 'Trajanje ispita' }
                ];
            }
        };
    });