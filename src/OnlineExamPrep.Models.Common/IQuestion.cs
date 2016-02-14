using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IQuestion
    {
        string Id { get; set; }
        string QuestionTypeId { get; set; }
        string Text { get; set; }
        ICollection<IAnswerChoice> AnswerChoices { get; set; }
        ICollection<IAnswerStep> AnswerSteps { get; set; }
        ICollection<IExamQuestion> ExamQuestions { get; set; }
        IQuestionType QuestionType { get; set; }
        ICollection<IQuestionPicture> QuestionPictures { get; set; }
    }
}
