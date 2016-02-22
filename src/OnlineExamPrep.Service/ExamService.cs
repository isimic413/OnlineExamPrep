using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineExamPrep.Models.Common.ParamsModel;

namespace OnlineExamPrep.Service
{
    public class ExamService : IExamService
    {
        protected IExamRepository examRepository { get; private set; }
        protected IQuestionRepository questionRepository { get; private set; }

        public ExamService(IExamRepository examRepository, IQuestionRepository questionRepository)
        {
            this.examRepository = examRepository;
            this.questionRepository = questionRepository;
        }

        public async Task<List<dynamic>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams)
        {
            var exams = await examRepository.GetPageWithQuestionsAndTestingAreaAsync(pagingParams);
            return exams.Select(exam => (dynamic)new {
                Id = exam.Id,
                DurationInMinutes = exam.DurationInMinutes,
                NumberOfQuestions = exam.ExamQuestions.Count,
                Title = String.Format("{0} ({1} {2}.)", exam.TestingArea.Title, ExamTerms.GetExamTermName(exam.Term), exam.Year)
            }).ToList();
        }

        public Task<IExamParams> GetExamForUpdateAsync(string examId)
        {
            return examRepository.GetExamForUpdateAsync(examId);
        }

        public async Task<dynamic> GetExamQuestionsAsync(string examId)
        {
            var examQuestions = await examRepository.GetExamQuestionsAsync(examId);
            var eqList = examQuestions.Select(eq => (dynamic)new
            {
                Id = eq.Id,
                Number = eq.Number,
                QuestionId = eq.QuestionId,
                QuestionText = eq.Question.Text
            }).ToList();
            var exam = await examRepository.GetExamForUpdateAsync(examId);
            return (dynamic)new { 
                Questions = eqList,
                ExamTitle = String.Format("{0} ({1} {2}.)", exam.TestingArea.Title, ExamTerms.GetExamTermName(exam.Term), exam.Year)
            };
        }

        public Task<int> InsertAsync(IExam exam)
        {
            exam.Id = Guid.NewGuid().ToString();
            return examRepository.InsertAsync(exam);
        }

        public Task<int> UpdateAsync(IExam exam)
        {
            return examRepository.UpdateAsync(exam);
        }

        public Task<int> DeleteAsync(string examId)
        {
            return examRepository.DeleteAsync(examId);
        }

        public async Task<int> UpdateQuestionOrderAsync(string examId, IExamQuestion[] examQuestions)
        {
            var unitOfWork = questionRepository.GetUnitOfWork();

            var existingEqs = await examRepository.GetExamQuestionsAsync(examId);
            var questionsToDelete = existingEqs.Where(e => !examQuestions.Select(eq => eq.Id).Contains(e.Id));
            foreach(var q in questionsToDelete)
            {
                await questionRepository.AddForDeleteAsync(unitOfWork, q.QuestionId);
            }
            foreach (var eq in examQuestions)
            {
                await examRepository.AddExamQuestionForUpdateAsync(unitOfWork, eq);
            }

            return await unitOfWork.CommitAsync();
        }
    }
}
