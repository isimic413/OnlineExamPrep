angular.module('onlineExamPrep.components')
    .directive('oepFooter', function ($sce, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/footer.html',
            scope: {
            },
            link: function (scope) {
                var vm = {};
                scope.vm = vm;

                vm.message = 'MathOS, 2015.'
            }
        }
    }
    );
