angular.module('onlineExamPrep.pages')
    .directive('oepLogin', function ($state, Paths, AccountService, UserService, Principal, TokenService, Lookups) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.account + 'login.html',
            scope: {
                vm: '='
            },
            link: function (scope) {
                var vm = scope.vm;
                
                vm.login = function () {
                    if (!scope.loginForm.$valid) {
                        console.log(scope.loginForm.$error.required);
                        return;
                    }

                    scope.$root.loadingContent = true;
                    AccountService.login(vm.user.login).then(function (response) {
                        TokenService.setToken(response.data);
                        UserService.getApplicationData().then(function (data) {
                            var principalData = {
                                role: data.role
                            };
                            var lookupData = {
                                testingArea: data.testingAreas,
                                questionType: data.questionTypes
                            };
                            Principal.setCurrent(principalData);
                            Lookups.setLookups(lookupData);

                            $state.go('main.home');
                        });
                    }, function (data, error) {
                        console.log(error);
                    }, function () {
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });
