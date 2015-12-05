using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class QuestionEntity
    {
        public QuestionEntity()
        {
            this.AnswerChoices = new List<AnswerChoiceEntity>();
            this.AnswerSteps = new List<AnswerStepEntity>();
            this.ExamQuestions = new List<ExamQuestionEntity>();
            this.QuestionPictures = new List<QuestionPictureEntity>();
        }

        public string Id { get; set; }
        public string QuestionTypeId { get; set; }
        public string TestingAreaId { get; set; }
        public string Text { get; set; }
        public byte Points { get; set; }
        public virtual ICollection<AnswerChoiceEntity> AnswerChoices { get; set; }
        public virtual ICollection<AnswerStepEntity> AnswerSteps { get; set; }
        public virtual ICollection<ExamQuestionEntity> ExamQuestions { get; set; }
        public virtual QuestionTypeEntity QuestionType { get; set; }
        public virtual TestingAreaEntity TestingArea { get; set; }
        public virtual ICollection<QuestionPictureEntity> QuestionPictures { get; set; }
    }
}
