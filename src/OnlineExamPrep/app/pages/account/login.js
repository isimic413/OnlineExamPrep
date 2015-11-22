angular.module('onlineExamPrep.pages')
    .directive('oepLogin', function (Paths, AccountService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.account + 'login.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.user = {
                    userName: null,
                    password: null
                };

                vm.login = function () {
                    if (!scope.loginForm.$valid) {
                        console.log(scope.loginForm.$error.required);
                        return;
                    }

                    vm.showSpinner = true;
                    AccountService.login(vm.user).success(function (data) {
                        console.log('jej');
                        console.log(data);
                    }).error(function (data, error) {
                        console.log('buuuu');
                        console.log(error);
                    }).finally(function () {
                        vm.showSpinner = false;
                    });
                };
            }
        };
    });