angular.module('onlineExamPrep.pages')
    .directive('oepHome', function (Paths) {
        'use strict';

        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.home + 'home.html',
            scope: {
            },
            link: function () {
            }
        };
    });
