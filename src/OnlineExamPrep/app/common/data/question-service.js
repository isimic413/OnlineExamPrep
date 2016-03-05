angular.module('onlineExamPrep.common')
    .service('QuestionService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.question;

        this.getQuestion = function (questionId) {
            return DataService.get(path + '/' + questionId, questionId);
        };

        this.getQuestionCollection = function (pagingParams) {
            return DataService.post(path + '/page', pagingParams);
        };

        this.saveQuestion = function (params) {
            if (params.question && params.question.id) {
                return DataService.put(path, params);
            }
            else {
                return DataService.post(path, params);
            }
        };

        this.deleteQuestion = function (questionId) {
            return DataService.delete(path + '/' + questionId, questionId);
        };
    });
