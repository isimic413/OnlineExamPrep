angular.module('onlineExamPrep.common')
    .service('UserService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.user;

        this.getUserRole = function (userId) {
            return DataService.get(path + '/role/' + userId, userId);
        };

        this.getApplicationData = function () {
            return DataService.get(path + '/applicationData');
        };
    });
