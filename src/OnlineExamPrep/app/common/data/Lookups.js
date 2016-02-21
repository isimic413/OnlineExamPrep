angular.module('onlineExamPrep.common')
    .service('Lookups', function ($window) {

        var self = this;

        var testingAreas = {};
        var questionTypes = {};

        this.setLookups = function (data) {
            _.each(data.testingArea, function (ta) {
                testingAreas[ta.abbreviation] = angular.copy(ta);
            });
            _.each(data.questionType, function (qt) {
                questionTypes[qt.abbreviation] = angular.copy(qt);
            });
        };

        this.getTestingAreas = function () {
            return testingAreas;
        };

        this.getQuestionTypes = function () {
            return questionTypes;
        };
    });
