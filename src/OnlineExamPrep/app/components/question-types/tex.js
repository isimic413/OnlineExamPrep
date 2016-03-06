angular.module('onlineExamPrep.components')
    .directive('oepTex', function () {
        'use strict';

        return {
            attribute: 'A',
            require: {
                ngModel: '=',
                textFrom: '@'
            },
            link: function (scope, element, attrs) {
                var propToWatch = attrs.textFrom + '.text';
                var deregisterWatcher = scope.$watch(propToWatch, function (value) {
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