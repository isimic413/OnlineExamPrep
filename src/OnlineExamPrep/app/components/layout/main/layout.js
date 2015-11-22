angular.module('onlineExamPrep.components')
    .directive('oepMainLayout', function ($sce, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.components + 'layout/main/layout.html',
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
