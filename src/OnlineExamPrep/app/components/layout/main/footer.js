angular.module('onlineExamPrep.components')
    .directive('oepFooter', function (Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/main/footer.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                vm.date = moment().format('YYYY');
            }
        }
    });
