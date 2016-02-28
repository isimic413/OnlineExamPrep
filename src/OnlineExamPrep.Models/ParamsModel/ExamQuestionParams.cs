using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class ExamQuestionParams : IExamQuestionParams
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string ExamId { get; set; }
        public int Number { get; set; }
        public IExam Exam { get; set; }
        public IQuestion Question { get; set; }
        public ITestingArea TestingArea { get; set; }
    }
}
