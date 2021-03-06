﻿angular.module('onlineExamPrep.pages')
    .directive('oepExamEdit', function ($q, $state, Constants, ExamService, Paths, TestingAreaService) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.exam + 'exam-edit.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                vm.showForm = !$state.params.id;
                vm.exam = {};
                vm.examTitle = '';

                vm.examTerms = {
                    data: _.map(Constants.examTerms, function (term) { return term; }),
                    model: { id: Constants.examTerms.summer.id },
                    dropdownText: Constants.examTerms.summer.title
                };

                vm.testingAreas = {
                    data: [],
                    model: {},
                    dropdownText: 'Odaberite'
                };

                if ($state.params.id) {
                    $q.all([
                        TestingAreaService.getDataset({}),
                        ExamService.getExam($state.params.id)
                    ]).then(function (responses) {
                        vm.testingAreas.data = responses[0].data;

                        var examData = responses[1].data;                        
                        vm.exam = examData;
                        vm.testingAreas.model.id = examData.testingAreaId;

                        vm.showForm = true;
                    });
                }
                else {
                    TestingAreaService.getDataset({}).success(function (data) {
                        vm.testingAreas.data = data;
                    });
                }
                
                vm.saveExam = function () {
                    if (!scope.examExamForm.$valid) {
                        return;
                    }

                    vm.exam.testingAreaId = vm.testingAreas.model.id;
                    vm.exam.term = vm.examTerms.model.id;

                    ExamService.saveExam(vm.exam).success(function () {
                        $state.go('main.exams');
                    });
                };

                scope.$watch(function () {
                    var area = vm.testingAreas.model.id ? _.find(vm.testingAreas.data, function (option) { return option.id === vm.testingAreas.model.id; }).title : undefined;
                    var term = vm.examTerms.dropdownText ? vm.examTerms.dropdownText : undefined;
                    var year = vm.exam.year ? vm.exam.year : undefined;

                    return area && term && year ? area + ' (' + term + ' ' + year + '.)' : undefined;
                }, function (newVal) {
                    vm.examTitle = newVal;
                });
            }
        };
    });
