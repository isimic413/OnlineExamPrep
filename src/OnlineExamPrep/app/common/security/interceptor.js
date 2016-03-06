angular.module('onlineExamPrep.common')
    .service('Interceptor', function ($injector) {
        'use strict';

        return {
            request: function (config) {
                var tokenService = $injector.get('TokenService');
                var token = tokenService.getToken();
                if (token) {
                    if (!config.headers) {
                        config.headers = {};
                    }
                    config.headers.Authorization = 'Bearer ' + token.access_token;
                }
                return config;
            }
        };
    });
