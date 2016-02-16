using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class ExamQuestion : IExamQuestion
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string ExamId { get; set; }
        public int Number { get; set; }
    }
}
