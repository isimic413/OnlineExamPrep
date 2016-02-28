using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class ExamEntity
    {
        public ExamEntity()
        {
            this.ExamQuestions = new List<ExamQuestionEntity>();
            this.UserExamResults = new List<UserExamResultEntity>();
        }

        public string Id { get; set; }
        public string TestingAreaId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Year { get; set; }
        public byte Term { get; set; }
        public virtual TestingAreaEntity TestingArea { get; set; }
        public virtual ICollection<ExamQuestionEntity> ExamQuestions { get; set; }
        public virtual ICollection<UserExamResultEntity> UserExamResults { get; set; }
    }
}
