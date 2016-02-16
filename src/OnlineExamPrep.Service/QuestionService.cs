using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class QuestionService : IQuestionService
    {
        protected IQuestionRepository questionRepository { get; private set; }
        protected IAnswerChoiceRepository answerChoiceRepository { get; private set; }
        protected IExamRepository examRepository { get; private set; }

        public QuestionService(
            IQuestionRepository questionRepository, 
            IAnswerChoiceRepository answerChoiceRepository,
            IExamRepository examRepository
            )
        {
            this.questionRepository = questionRepository;
            this.answerChoiceRepository = answerChoiceRepository;
            this.examRepository = examRepository;
        }

        public async Task<List<dynamic>> GetPageAsync(PagingParams pagingParams)
        {
            var questions = await questionRepository.GetPageAsync(pagingParams);
            return questions.Select(question => (dynamic)new {
                Id = question.Id,
                TextPreview = question.Text.Length < 100 ? question.Text : question.Text.Substring(0, 100),
                QuestionType = question.QuestionType.Title,
                Points = question.AnswerChoices.Sum(choice => choice.Points),
                Term = String.Format("{0} {1}.", ExamTerms.GetExamTermName(question.ExamQuestions.ElementAt(0).Exam.Term), question.ExamQuestions.ElementAt(0).Exam.Year),
                Area = question.ExamQuestions.ElementAt(0).TestingArea.Title
            }).ToList();
        }

        public Task<IQuestionParams> GetQuestionForUpdateAsync(string questionId)
        {
            return questionRepository.GetQuestionWithChoicesAndPicuresAsync(questionId);
        }

        public async Task<int> InsertAsync(IQuestion question, IAnswerChoice[] answerChoices, string examId)
        {
            var questionId = Guid.NewGuid().ToString();
            question.Id = questionId;

            if (String.IsNullOrEmpty(examId))
            {
                throw new ArgumentException("Exam");
            }
            var correctAnswers = 0;
            foreach (var choice in answerChoices)
            {
                if (choice.Points > 0)
                {
                    correctAnswers++;
                }
            }
            if (correctAnswers == 0)
            {
                throw new ArgumentException("AnswerChoice");
            }

            var examQuestion = new ExamQuestion();
            examQuestion.ExamId = examId;
            examQuestion.QuestionId = questionId;
            examQuestion.Id = Guid.NewGuid().ToString();
            examQuestion.Number = await examRepository.GetNumberOfQuestionsAsync(examQuestion.ExamId) + 1;

            var unitOfWork = questionRepository.GetUnitOfWork();
            await questionRepository.AddForInsertAsync(unitOfWork, question);
            await examRepository.AddExamQuestionForInsert(unitOfWork, examQuestion);
            foreach(var choice in answerChoices)
            {
                choice.QuestionId = questionId;
                choice.Id = Guid.NewGuid().ToString();
                await answerChoiceRepository.AddForInsertAsync(unitOfWork, choice);
            }

            return await unitOfWork.CommitAsync();
        }

        public Task<int> DeleteQuestionAsync(string questionId)
        {
            return questionRepository.DeleteAsync(questionId);
        }
    }
}
