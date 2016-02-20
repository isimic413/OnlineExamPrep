angular.module('onlineExamPrep.pages')
    .directive('oepLogin', function (Paths, AccountService, UserService, Principal) {
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
                        var token = 'Bearer ' + data['access_token'];
                        UserService.getApplicationData(token).success(function (data) {

                        });
                    }).error(function (data, error) {
                        console.log(error);
                    }).finally(function () {
                        vm.showSpinner = false;
                    });
                };
            }
        };
    });