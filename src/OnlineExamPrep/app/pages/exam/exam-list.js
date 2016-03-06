angular.module('onlineExamPrep.pages')
    .directive('oepExamList', function ($state, ExamService, Paths) {
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

                vm.columns = [
                    { id: 'title', display: 'Ispit' },
                    { id: 'numberOfQuestions', display: 'Broj zadataka' },
                    { id: 'durationInMinutes', display: 'Trajanje (u minutama)' }
                ];

                var editQuestionOrder = function () {
                    var selectedExam = _.find(vm.entities, function (exam) {
                        return exam.id === vm.checkedItem.id;
                    });

                    $state.go('main.exam/questions', { id: selectedExam.id }, { inherit: false });
                };

                vm.customAction = {
                    buttonText: 'Zadaci',
                    method: editQuestionOrder
                };
            }
        };
    });