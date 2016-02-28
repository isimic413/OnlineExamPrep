using OnlineExamPrep.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class ExamParams : OnlineExamPrep.Models.Common.ParamsModel.IExamParams
    {
        public string Id { get; set; }
        public string TestingAreaId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Year { get; set; }
        public byte Term { get; set; }
        public ITestingArea TestingArea { get; set; }
        public ICollection<IExamQuestion> ExamQuestions { get; set; }
        public ICollection<IUserExamResult> UserExamResults { get; set; }
    }
}
