angular.module('onlineExamPrep.pages')
    .directive('oepQuestionTypeEdit', function ($state, QuestionTypeService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.questionType + 'question-type-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.questionType = {};

                if ($state.params.id) {
                    QuestionTypeService.getQuestionTypeById($state.params.id).then(function (data) {
                        vm.questionType = data;
                        vm.showForm = true;
                    });
                }
                else {
                    vm.showForm = true;
                }

                vm.saveQuestionType = function () {
                    if (!scope.questionTypeEditForm.$valid) {
                        return;
                    }

                    QuestionTypeService.saveQuestionType(vm.questionType).then(function () {
                        $state.go('main.question-types');
                    });
                }
            }
        };
    });