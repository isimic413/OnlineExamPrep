angular.module('onlineExamPrep.common')
    .service('DataService', function ($http, $q) {

        var deferred = $q.defer();

        function resolveRequestResponse(promise) {
            return promise.success(function (data) {
                return deferred.resolve(data);
            }).error(function (data, status, headers, config, statusText) {
                console.log(data);
                console.log(status);
                console.log(headers);
                console.log(config);
                console.log(statusText);
            });
        }

        this.get = function (path, params) {
            return resolveRequestResponse($http.get(path, params));
        };

        this.post = function (path, params) {
            return resolveRequestResponse($http.post(path, params));
        };

        this.put = function (path, params) {
            return resolveRequestResponse($http.put(path, params));
        };

        this.delete = function (path, params) {
            return resolveRequestResponse($http.delete(path, params));
        };
    });