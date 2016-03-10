angular.module('onlineExamPrep.pages')
    .directive('oepRegister', function (Paths, AccountService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.account + 'register.html',
            scope: {
                vm: '='
            },
            link: function (scope) {
                var vm = scope.vm;

                vm.register = function () {
                    if (!scope.registrationForm.$valid) {
                        console.log(scope.registrationForm.$error.required);
                        return;
                    }

                    scope.$root.loadingContent = true;
                    AccountService.registerUser(vm.user.register).then(function () {
                        vm.user.login.userName = vm.user.register.email;
                        vm.user.login.password = vm.user.register.password;
                        vm.login();
                    }, function (response) {
                        console.log('create error modal');
                        console.log(error);
                    }, function () {
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });