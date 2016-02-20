angular.module('onlineExamPrep.common')
    .service('DataService', function ($rootScope, $http, $q) {

        var deferred = $q.defer();

        function sendRequest(config) {
            $rootScope.loadingContent = true;

            return $http(config).success(function (data) {
                $rootScope.loadingContent = false;
                return deferred.resolve(data);
            }).error(function (data, status, headers, config, statusText) {
                $rootScope.loadingContent = false;
                console.log(data);
                console.log(status);
                console.log(headers);
                console.log(config);
                console.log(statusText);
            });
        }

        this.get = function (path, params, options) {
            var config = {
                method: 'get',
                url: path,
                data: params
            };
            if (options && options.header) {
                config.header = options.header;
            }
            return sendRequest(config);
        };

        this.post = function (path, params, options) {
            var config = {
                method: 'post',
                url: path,
                data: params
            };
            if (options && options.header) {
                config.header = options.header;
            }
            return sendRequest(config);
        };

        this.put = function (path, params, options) {
            var config = {
                method: 'put',
                url: path,
                data: params
            };
            if (options && options.header) {
                config.header = options.header;
            }
            return sendRequest(config);
        };

        this.delete = function (path, params, options) {
            var config = {
                method: 'put',
                url: path,
                data: params
            };
            if (options && options.header) {
                config.header = options.header;
            }
            return sendRequest(config);
        };
    });