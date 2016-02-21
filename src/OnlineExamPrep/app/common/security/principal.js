angular.module('onlineExamPrep.common')
    .service('Principal', function ($window) {

        var principal = null;
        var self = this;

        this.setCurrent = function (data) {
            $window.localStorage.principal = angular.toJson(data);
            principal = data;
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

        this.isInRoles = function (roles) {
            return roles.split(',').indexOf(principal.role) > -1;
        };
    });