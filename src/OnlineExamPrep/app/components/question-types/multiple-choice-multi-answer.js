angular.module('onlineExamPrep.components')
    .directive('oepMultipleChoiceMultiAnswer', function ($state, $window, Paths, QuestionService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'question-types/multiple-choice-multi-answer.html',
            scope: {
                vm: '=',
                enableAnswer: '='
            },
            link: function (scope) {
                var vm = scope.vm;

                var deregisterWatcher = scope.$watch('choices', function (newVal) {
                    vm.choices = scope.choices;
                }, true);

                scope.$on('$destroy', function () {
                    deregisterWatcher();
                });
                
                
                vm.refreshSelection = function (choice) {
                    if (!vm.selectedAnswer) {
                        vm.selectedAnswer = [choice.id];
                        choice.isSelected = true;
                    }
                    else {
                        var choiceIdx = vm.selectedAnswer.indexOf(choice.id);
                        if (choiceIdx > -1) {
                            vm.selectedAnswer.splice(choiceIdx, 1);
                            choice.isSelected = false;
                            if (!vm.selectedAnswer.length) {
                                delete vm.selectedAnswer;
                            }
                        }
                        else {
                            vm.selectedAnswer.push(choice.id);
                            choice.isSelected = true;
                        }
                    }
                };
            }
        };
    });
