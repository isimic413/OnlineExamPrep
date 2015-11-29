angular.module('onlineExamPrep.common')
    .service('QuestionTypeService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.questionType;

        this.getQuestionTypeById = function (questionTypeId) {
            return DataService.get(path + '/' + questionTypeId, questionTypeId);
        };

        this.getQuestionTypeCollection = function (pagingParams) {
            return DataService.post(path + '/getCollection', pagingParams);
        };

        this.saveQuestionType = function (questionType) {
            if (questionType.id) {
                return DataService.put(path + '/' + questionType.id, questionType);
            }
            else {
                return DataService.post(path, questionType);
            }
        };

        this.deleteQuestionType = function (questionTypeId) {
            return DataService.delete(path + '/' + questionTypeId, questionTypeId);
        };
    });
