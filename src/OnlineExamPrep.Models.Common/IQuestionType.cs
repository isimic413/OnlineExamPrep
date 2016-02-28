using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IQuestionType
    {
        string Id { get; set; }
        string Title { get; set; }
        string Abbreviation { get; set; }
    }
}
