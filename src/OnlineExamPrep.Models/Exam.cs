using OnlineExamPrep.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Models
{
    public class Exam : IExam
    {
        public string Id { get; set; }
        public string TestingAreaId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Year { get; set; }
        public byte Term { get; set; }
    }
}
