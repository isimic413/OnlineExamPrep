using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class QuestionType : IQuestionType
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
    }
}
