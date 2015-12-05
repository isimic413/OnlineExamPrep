using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IQuestion
    {
        string Id { get; set; }
        string QuestionTypeId { get; set; }
        string TestingAreaId { get; set; }
        string Text { get; set; }
        byte Points { get; set; }
        ICollection<IAnswerChoice> AnswerChoices { get; set; }
        ICollection<IAnswerStep> AnswerSteps { get; set; }
        IQuestionType QuestionType { get; set; }
        ITestingArea TestingArea { get; set; }
        ICollection<IQuestionPicture> QuestionPictures { get; set; }
    }
}
