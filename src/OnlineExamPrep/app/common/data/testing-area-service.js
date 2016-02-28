angular.module('onlineExamPrep.common')
    .service('TestingAreaService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.testingArea;

        this.getTestingAreaById = function (testingAreaId) {
            return DataService.get(path + '/' + testingAreaId, testingAreaId);
        };

        this.getDataset = function (pagingParams) {
            return DataService.post(path + '/GetDataset', pagingParams);
        };

        this.saveTestingArea = function (testingArea) {
            if (testingArea.id) {
                return DataService.put(path + '/' + testingArea.id, testingArea);
            }
            else {
                return DataService.post(path, testingArea);
            }
        };

        this.deleteTestingArea = function (testingAreaId) {
            return DataService.delete(path + '/' + testingAreaId, testingAreaId);
        };
    });