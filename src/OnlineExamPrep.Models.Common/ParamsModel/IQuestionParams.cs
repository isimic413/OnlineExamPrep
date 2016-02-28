using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IQuestionParams
    {
        string Id { get; set; }
        string QuestionTypeId { get; set; }
        string Text { get; set; }
        ICollection<IAnswerChoice> AnswerChoices { get; set; }
        ICollection<IAnswerStep> AnswerSteps { get; set; }
        ICollection<IExamQuestionParams> ExamQuestions { get; set; }
        IQuestionType QuestionType { get; set; }
        ICollection<IQuestionPicture> QuestionPictures { get; set; }
    }
}
