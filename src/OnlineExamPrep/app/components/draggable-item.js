angular.module('onlineExamPrep.components')
    .directive('oepDraggableItem', function ($state, $window, Paths, QuestionService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'draggable-item.html',
            scope: {
                index: '=',
                text: '=',
                itemId: '='
            },
            link: function (scope) {
                scope.deleteQuestion = function () {
                    QuestionService.deleteQuestion(scope.itemId).then(function (data) {
                        scope.$parent.$parent.vm.questions.list.splice(scope.index-1, 1);
                    });
                };

                scope.editQuestion = function () {
                    var url = $state.href('main.question/edit', { id: scope.itemId });
                    $window.open(url, '_blank');
                };
            }
        };
    });
