using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common
{
    public interface ITestingArea
    {
        string Id { get; set; }
        string Title { get; set; }
        string Abbreviation { get; set; }
        ICollection<IQuestion> Questions { get; set; }
    }
}
