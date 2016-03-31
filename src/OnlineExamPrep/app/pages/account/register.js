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
                    delete scope.$root.error;
                    scope.$root.loadingContent = true;
                    AccountService.registerUser(vm.user.register).then(function () {
                        vm.user.login.userName = vm.user.register.email;
                        vm.user.login.password = vm.user.register.password;
                        vm.login();
                    }, function (response) {
                        scope.$root.error = 'Neuspješna prijava' + (response.data && response.data.error_description ? ': "' + response.data.error_description + '".' : '.');
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });