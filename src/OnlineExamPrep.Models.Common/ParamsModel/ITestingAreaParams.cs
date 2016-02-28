using System.Collections.Generic;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface ITestingAreaParams
    {
        string Id { get; set; }
        string Title { get; set; }
        string Abbreviation { get; set; }
        ICollection<IExam> Exams { get; set; }
    }
}
