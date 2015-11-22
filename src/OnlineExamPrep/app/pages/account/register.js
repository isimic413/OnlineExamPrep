angular.module('onlineExamPrep.pages')
    .directive('oepRegister', function (Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.account + 'register.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.user = {
                    email: null,
                    password: null,
                    confirmPassword: null
                };

                vm.register = function () {
                    if (!scope.registrationForm.$valid) {
                        return;
                    }

                    vm.showSpinner = true;
                };
            }
        };
    });