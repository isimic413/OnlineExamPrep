using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Models.Common
{
    public interface IExam
    {
        string Id { get; set; }
        string TestingAreaId { get; set; }
        int DurationInMinutes { get; set; }
        int Year { get; set; }
        byte Term { get; set; }
        ITestingArea TestingArea { get; set; }
        ICollection<IUserExamResult> UserExamResults { get; set; }
    }
}
