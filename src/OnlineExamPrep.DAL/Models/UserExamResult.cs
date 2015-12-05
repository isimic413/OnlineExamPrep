using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class UserExamResultEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ExamId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Points { get; set; }
        public int CorrectAnswers { get; set; }
        public System.DateTime TimeTaken { get; set; }
        public virtual ExamEntity Exam { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
