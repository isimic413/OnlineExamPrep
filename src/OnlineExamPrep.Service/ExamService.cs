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

        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
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
    }
}
