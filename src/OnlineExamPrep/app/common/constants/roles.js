angular.module('onlineExamPrep.common')
    .constant('Roles', {
        groupUser: 'User',
        groupInfAdmin: 'InfAdmin',
        groupMathAdmin: 'MathAdmin',
        groupAppAdmin: 'AppAdmin',

        groupAllRoles: ['User', 'InfAdmin', 'MathAdmin', 'AppAdmin']
    });