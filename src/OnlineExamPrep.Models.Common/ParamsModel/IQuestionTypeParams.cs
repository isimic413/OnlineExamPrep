using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IQuestionTypeParams
    {
        string Id { get; set; }
        string Title { get; set; }
        string Abbreviation { get; set; }
        ICollection<IQuestion> Questions { get; set; }
    }
}
