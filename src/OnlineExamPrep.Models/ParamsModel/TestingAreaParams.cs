using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class TestingAreaParams : OnlineExamPrep.Models.Common.ParamsModel.ITestingAreaParams
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<IExam> Exams { get; set; }
    }
}
