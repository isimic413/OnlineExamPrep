using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models
{
    public class Question : IQuestion
    {
        public string Id { get; set; }
        public string QuestionTypeId { get; set; }
        public string Text { get; set; }
        public ICollection<IAnswerChoice> AnswerChoices { get; set; }
        public ICollection<IAnswerStep> AnswerSteps { get; set; }
        public ICollection<IExamQuestion> ExamQuestions { get; set; }
        public IQuestionType QuestionType { get; set; }
        public ICollection<IQuestionPicture> QuestionPictures { get; set; }
    }
}
