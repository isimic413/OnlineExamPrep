angular.module('onlineExamPrep.common')
    .service('RoleService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.role;

        this.getRoleById = function (roleId) {
            return DataService.get(path + '/' + roleId, roleId);
        };

        this.getRoleCollection = function (pagingParams) {
            return DataService.post(path + '/page', pagingParams);
        };

        this.saveRole = function (role) {
            if (role.id) {
                return DataService.put(path + '/' + role.id, role);
            }
            else {
                return DataService.post(path, role);
            }
        };

        this.deleteRole = function (roleId) {
            return DataService.delete(path + '/' + roleId, roleId);
        };
    });
