using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IAnswerChoiceParams
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        string Text { get; set; }
        byte Points { get; set; }
        IQuestion Question { get; set; }
        ICollection<IAnswerChoicePicture> AnswerChoicePictures { get; set; }
    }
}
