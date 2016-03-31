angular.module('onlineExamPrep.pages')
    .directive('oepExamSimulator', function ($uibModal, $window, $q, $state, Constants, Lookups, ExamService, Paths) {
        'use strict';
        return {
            restrict: 'E',
            templateUrl: Paths.app.pages + Paths.templates.simulator + 'exam-simulator.html',
            scope: {
            },
            link: function (scope) {
                scope.vm = {};
                var vm = scope.vm;

                scope.$root.title = $state.params.examTitle;

                vm.questionTypes = Lookups.getQuestionTypes();

                ExamService.fullExamQuestions($state.params.id).then(function (data) {
                    vm.questions = _.sortBy(data.questions, function (question) {
                        question.displayNumber = ('0' + question.number).slice(-2) + '.';
                        if (question.questionType.id === vm.questionTypes.alt.id || question.questionType.id === vm.questionTypes.vis_jedan.id) {
                            question.correctAnswer = _.find(question.choices, function (choice) { return choice.isCorrect; }).id;
                        }
                        else if(question.questionType.id === vm.questionTypes.kra.id || question.questionType.id === vm.questionTypes.pro.id){
                            question.correctAnswer = question.choices[0].text;
                        }
                        else if (question.questionType.id === vm.questionTypes.vis_multi.id) {
                            question.correctAnswer = _.map(_.filter(question.choices, function (choice) { return choice.isCorrect; }), function (choice) { return choice.id; });
                        }
                        question.maxPoints = 0;
                        _.each(question.choices, function (choice) { question.maxPoints += choice.points; });

                        return question.number;
                    });
                    vm.numberOfQuestion = vm.questions.length;
                    vm.examLength = parseInt(data.exam.durationInMinutes, 10) * 60;
                    vm.activeQuestionNumber = 1;
                });

                setHeight();

                scope.$watch(function () { return $window.innerHeight; }, function () {
                    setHeight();
                });


                function setHeight() {
                    var e = angular.element('#simulator');
                    var offset = $window.innerHeight - 225;
                    e.css('height', (offset > 350 ? offset : 350) + 'px');
                }

                scope.$watch('vm.examLength', function (newVal) {
                    if (newVal < 0) {
                        vm.examStopped = true;
                        openModal();
                    }
                });

                function openModal() {
                    function modalCtrl($scope, $uibModalInstance, vm) {
                        $scope.vm = vm;
                        $scope.ok = function () {
                            $uibModalInstance.close();
                        };
                    }

                    var modalInstance = $uibModal.open({
                        animation: true,
                        templateUrl: 'modelTemplate.html',
                        controller: modalCtrl,
                        resolve: {
                            vm: function () {
                                return vm;
                            }
                        }
                    });

                    vm.result = {
                        questions: {
                            correct: 0,
                            total: 0
                        },
                        points: {
                            gained: 0,
                            total: 0
                        },
                        longAnswer: {
                            count: 0,
                            points: 0
                        }
                    };

                    _.each(vm.questions, function (question) {
                        if (question.selectedAnswer || question.questionType.id == vm.questionTypes.pro.id) {
                            if (question.questionType.id === vm.questionTypes.alt.id || question.questionType.id === vm.questionTypes.vis_jedan.id) {
                                question.isCorrect = question.correctAnswer === question.selectedAnswer;
                            }
                            else if (question.questionType.id === vm.questionTypes.kra.id) {
                                question.isCorrect = question.correctAnswer.toLowerCase() === question.selectedAnswer.toLowerCase();
                            }
                            else if (question.questionType.id === vm.questionTypes.vis_multi.id) {
                                if (question.correctAnswer.length === question.selectedAnswer.length) {
                                    question.isCorrect = true;
                                    _.each(question.correctAnswer, function (id) {
                                        if (!_.find(question.selectedAnswer, function (sId) { return id === sId; })) {
                                            question.isCorrect = false;
                                        }
                                    });
                                }
                            }
                            else {
                                vm.result.longAnswer.count++;
                                vm.result.longAnswer.points += question.maxPoints;
                                question.requiresAttention = question.selectedAnswer ? true : false;
                            }
                        }
                        vm.result.questions.total++;
                        vm.result.points.total += question.maxPoints;
                        if (question.isCorrect) {
                            vm.result.questions.correct++;
                            vm.result.points.gained += question.maxPoints;
                        }
                        else if (!question.selectedAnswer || (!question.requiresAttention && !question.isCorrect)) {
                            question.notCorrect = true;
                        }
                    });
                    vm.result.percentage = Math.round(100 * vm.result.points.gained / vm.result.points.total);
                }
            }
        };
    });
