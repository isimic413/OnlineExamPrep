angular.module('onlineExamPrep.common')
    .service('QuestionService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.question;

        this.getQuestion = function (questionId) {
            return DataService.get(path + '/' + questionId, questionId);
        };

        this.getQuestionCollection = function (pagingParams) {
            return DataService.post(path + '/getCollection', pagingParams);
        };

        this.saveQuestion = function (params) {
            if (params.question && params.question.id) {
                console.log("Not implemented yet.");
            }
            else {
                return DataService.post(path, params);
            }
        };
    });
