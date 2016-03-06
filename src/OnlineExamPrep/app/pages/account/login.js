﻿angular.module('onlineExamPrep.pages')
    .directive('oepLogin', function ($state, Paths, AccountService, UserService, Principal, TokenService, Lookups) {
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
                    userName: "admin@admin.com",
                    password: "asd@qwe"
                };

                vm.login = function () {
                    if (!scope.loginForm.$valid) {
                        console.log(scope.loginForm.$error.required);
                        return;
                    }

                    scope.$root.loadingContent = true;
                    AccountService.login(vm.user).success(function (data) {
                        TokenService.setToken(data);
                        UserService.getApplicationData().success(function (data) {
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
                    }).error(function (data, error) {
                        console.log(error);
                    }).finally(function () {
                        scope.$root.loadingContent = false;
                    });
                };
            }
        };
    });
