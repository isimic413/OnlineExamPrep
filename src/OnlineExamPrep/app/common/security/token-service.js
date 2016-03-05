angular.module('onlineExamPrep.common')
    .service('TokenService', function ($window) {
        'use strict';

        var token = null;

        this.setToken = function (tokenData) {
            $window.localStorage.token = angular.toJson(tokenData);
            token = tokenData;
        };

        this.getToken = function () {
            if (!token) {
                token = angular.fromJson($window.localStorage.token);
            }
            return token;
        };

        this.removeToken = function () {
            token = null;
            delete $window.localStorage.token;
        };
    });
