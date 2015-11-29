angular.module('onlineExamPrep.pages')
    .directive('oepQuestionTypeList', function ($uibModal, $state, QuestionTypeService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.questionType + 'question-type-list.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;
                vm.questionTypes = [];
                vm.checkedItem = {};
                vm.alerts = [];
                var alertTemplate = {
                    type: 'success',
                    msg: 'message'
                };

                QuestionTypeService.getQuestionTypeCollection().success(function (data) {
                    vm.questionTypes = data;
                });

                vm.toggleSelection = function (item) {
                    vm.checkedItem = vm.checkedItem.id === item.id ? {} : item;
                };
                
                vm.gotoEditScreen = function () {
                    $state.go('public.question-type/edit', { id: vm.checkedItem.id });
                };

                vm.delete = function () {
                    QuestionTypeService.deleteQuestionType(vm.checkedItem.id).success(function () {
                        var itemIdx = _.findIndex(vm.questionTypes, function (questionType) { return questionType.id === vm.checkedItem.id; });
                        vm.questionTypes.splice(itemIdx, 1);

                        vm.alerts.push(angular.extend(alertTemplate, {
                            msg: 'Obrisan tip pitanja "' + vm.checkedItem.title + '".'
                        }));
                    });
                };

                vm.closeAlert = function (index) {
                    vm.alerts.splice(index, 1);
                };
            }
        };
    });