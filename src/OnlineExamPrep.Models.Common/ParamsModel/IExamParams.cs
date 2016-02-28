using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IExamParams
    {
        string Id { get; set; }
        string TestingAreaId { get; set; }
        int DurationInMinutes { get; set; }
        int Year { get; set; }
        byte Term { get; set; }
        ITestingArea TestingArea { get; set; }
        ICollection<IExamQuestion> ExamQuestions { get; set; }
        ICollection<IUserExamResult> UserExamResults { get; set; }
    }
}
