angular.module('onlineExamPrep.common')
    .service('AccountService', function ($http, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.account;

        this.registerUser = function (userParams) {
            return $http.post(path + '/register', userParams);
        };

        this.login = function (loginParams) {
            return $http({
                method: 'post',
                url: Paths.token,
                header: { 'Content-Type': 'application/x-www-form-urlencoded' },
                data: 'grant_type=password&username=' + loginParams.userName + '&password=' + loginParams.password
            });
        };
    });