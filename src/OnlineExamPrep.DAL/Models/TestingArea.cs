using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class TestingAreaEntity
    {
        public TestingAreaEntity()
        {
            this.Exams = new List<ExamEntity>();
            this.Questions = new List<QuestionEntity>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public virtual ICollection<ExamEntity> Exams { get; set; }
        public virtual ICollection<QuestionEntity> Questions { get; set; }
    }
}
