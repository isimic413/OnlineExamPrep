angular.module('onlineExamPrep.common')
    .service('DataService', function ($rootScope, $http, $q) {

        function sendRequest(config) {
            var deferred = $q.defer();
            $rootScope.loadingContent = true;

            $http(config).then(function (response) {
                $rootScope.error = null;
                deferred.resolve(response.data);
            }, function (data) {
                $rootScope.error = data;
                deferred.reject();
            });

            $rootScope.loadingContent = false;
            return deferred.promise;
        }

        this.get = function (path, params, options) {
            var config = {
                method: 'get',
                url: path,
                data: params
            };
            if (options && options.headers) {
                config.headers = options.headers;
            }
            return sendRequest(config);
        };

        this.post = function (path, params, options) {
            var config = {
                method: 'post',
                url: path,
                data: params
            };
            if (options && options.headers) {
                config.headers = options.headers;
            }
            return sendRequest(config);
        };

        this.put = function (path, params, options) {
            var config = {
                method: 'put',
                url: path,
                data: params
            };
            if (options && options.headers) {
                config.headers = options.headers;
            }
            return sendRequest(config);
        };

        this.delete = function (path, params, options) {
            var config = {
                method: 'delete',
                url: path,
                data: params
            };
            if (options && options.headers) {
                config.headers = options.headers;
            }
            return sendRequest(config);
        };
    });