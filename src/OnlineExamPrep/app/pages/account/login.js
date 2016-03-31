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
                    delete scope.$root.error;
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

                            scope.$root.loadingContent = false;

                            $state.go('main.home');
                        });
                    }, function (response) {
                        scope.$root.error = 'Neuspješna prijava' + (response.data && response.data.error_description ? ': "' + response.data.error_description + '".' : '.');
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });
