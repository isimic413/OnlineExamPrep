using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface IQuestion
    {
        string Id { get; set; }
        string QuestionTypeId { get; set; }
        string Text { get; set; }
    }
}
