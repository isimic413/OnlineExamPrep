angular.module('onlineExamPrep.components')
    .directive('oepSingleselectDropdown', function ($state, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'singleselect-dropdown.html',
            scope: {
                selectedModel: '=',
                options: '=',
                settings: '='
            },
            link: function (scope) {
                if (!scope.selectedModel) {
                    scope.selectedModel = {};
                    scope.buttonText = scope.settings.defaultButtonText;
                }

                if (!scope.options) {
                    scope.options = [];
                }
                var settings = {
                    idProp: 'id',
                    displayProp: 'title',
                    buttonClass: 'btn-primary',
                    defaultButtonText: 'Odaberite' // Select
                }
                scope.settings = angular.extend(settings, scope.settings ? scope.settings : {});

                scope.getButtonText = function () {
                    var selectedModelId = scope.selectedModel[scope.settings.idProp] ? scope.selectedModel[scope.settings.idProp] : undefined;
                    if (selectedModelId) {
                        var option = _.find(scope.options, function (option) { return option.id === selectedModelId; });
                        return option ? option[scope.settings.displayProp] : scope.settings.defaultButtonText;
                    }
                    else {
                        return scope.settings.defaultButtonText;
                    }
                };

                scope.$watch(function () {
                    var selectedModelId = scope.selectedModel[scope.settings.idProp] ? scope.selectedModel[scope.settings.idProp] : undefined;
                    if (selectedModelId) {
                        var option = _.find(scope.options, function (option) { return option.id === selectedModelId; });
                        return option ? option[scope.settings.displayProp] : scope.settings.defaultButtonText;
                    }
                    else {
                        return scope.settings.defaultButtonText;
                    }
                }, function (newValue) {
                    scope.buttonText = newValue;
                });

                scope.setOption = function (optionId) {
                    var selectedOption = _.find(scope.options, function (option) { return option.id === optionId; });
                    if (selectedOption) {
                        scope.selectedModel[scope.settings.idProp] = selectedOption[scope.settings.idProp];
                    }
                    else {
                        scope.selectedModel = {};
                    }
                    scope.getButtonText();
                }
            }
        };
    });
