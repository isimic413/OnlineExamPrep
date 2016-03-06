angular.module('onlineExamPrep.components')
    .directive('oepTex', function () {
        'use strict';

        return {
            attribute: 'A',
            require: {
                ngModel: '=',
                propToWatch: '@'
            },
            link: function (scope, element, attrs) {
                var deregisterWatcher = scope.$watch(attrs.propToWatch, function (value) {
                    var script = value ? value : '';
                    element.html('');
                    element.append(script);
                    MathJax.Hub.Queue(['Typeset', MathJax.Hub, element[0]]);
                });

                scope.$on('$destroy', function () {
                    deregisterWatcher();
                });
            }
        };
    });