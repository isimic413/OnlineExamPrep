angular.module('onlineExamPrep.common')
    .service('Lookups', function ($window) {

        var self = this;

        var testingAreas = null;
        var questionTypes = null;

        this.setLookups = function (data) {
            testingAreas = {};
            questionTypes = {};

            _.each(data.testingArea, function (ta) {
                testingAreas[ta.abbreviation] = angular.copy(ta);
            });
            _.each(data.questionType, function (qt) {
                questionTypes[qt.abbreviation] = angular.copy(qt);
            });
            $window.localStorage.lookups = angular.toJson({
                questionTypes: questionTypes,
                testingAreas: testingAreas
            });
        };

        this.getTestingAreas = function () {
            if (!testingAreas) {
                loadLookups();
            }
            return testingAreas;
        };

        this.getQuestionTypes = function () {
            if (!questionTypes) {
                loadLookups();
            }
            return questionTypes;
        };

        function loadLookups() {
            var lookups = angular.fromJson($window.localStorage.lookups);
            testingAreas = lookups.testingAreas;
            questionTypes = lookups.questionTypes;
        }
    });
