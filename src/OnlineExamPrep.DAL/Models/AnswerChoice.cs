using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class AnswerChoiceEntity
    {
        public AnswerChoiceEntity()
        {
            this.AnswerChoicePictures = new List<AnswerChoicePictureEntity>();
        }

        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public byte Points { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public virtual ICollection<AnswerChoicePictureEntity> AnswerChoicePictures { get; set; }
    }
}
