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
                Title = String.Format("{0} {1}/{2} - ({3})", exam.TestingArea.Title, exam.Year-1, exam.Year, exam.Term == 1 ? "ljeto" : "zima"),
                Points = exam.ExamQuestions.Sum(eq => eq.Question.Points)
            }).ToList();
        }
    }
}
