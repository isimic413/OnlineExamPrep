﻿angular.module('onlineExamPrep.common')
    .service('ExamService', function (DataService, Paths) {
        var path = Paths.api.endpoint + Paths.api.paths.exam;

        this.getExamCollection = function (pagingParams) {
            return DataService.post(path + '/getPage', pagingParams);
        };

        this.getExam = function (examId) {
            //
        };

        this.saveExam = function (exam) {
            if (exam.id) {
                return DataService.put(path + '/' + exam.id, exam);
            }
            else {
                return DataService.post(path, exam);
            }
        };
    });