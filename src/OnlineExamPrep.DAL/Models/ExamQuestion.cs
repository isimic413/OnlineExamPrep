using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class ExamQuestionEntity
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string ExamId { get; set; }
        public int Number { get; set; }
        public virtual ExamEntity Exam { get; set; }
        public virtual QuestionEntity Question { get; set; }
    }
}
