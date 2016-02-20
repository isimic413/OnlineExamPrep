angular.module('onlineExamPrep.common')
    .service('Principal', function ($window) {

        var principal = null;
        var self = this;

        this.setCurrent = function (data) {
            $window.localStorage.principal = angular.toJson(data);
        };

        this.getCurrent = function () {
            if (!principal) {
                principal = angular.fromJson($window.localStorage.principal);
            }
            return principal;
        };

        this.removeCurrent = function () {
            principal = null;
            delete $window.localStorage.principal;
        };

        this.isAdminUser = function () {
            var currentPrincipal = self.getCurrent();
            return currentPrincipal && currentPrincipal.isAdmin;
        };
    });