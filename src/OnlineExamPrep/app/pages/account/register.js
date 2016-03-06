angular.module('onlineExamPrep.pages')
    .directive('oepRegister', function (Paths, AccountService) {
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
                        console.log(scope.registrationForm.$error.required);
                        return;
                    }

                    scope.$root.loadingContent = true;
                    AccountService.registerUser(vm.user).success(function (data) {
                        console.log('create modal');
                        console.log(data);
                    }).error(function (data, error, asd, wqer, sgi, aodg) {
                        console.log('create error modal');
                        console.log(error);
                    }).finally(function () {
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });