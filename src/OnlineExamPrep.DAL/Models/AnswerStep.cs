using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class AnswerStepEntity
    {
        public AnswerStepEntity()
        {
            this.AnswerStepPictures = new List<AnswerStepPictureEntity>();
        }

        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public byte Number { get; set; }
        public Nullable<byte> Points { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public virtual ICollection<AnswerStepPictureEntity> AnswerStepPictures { get; set; }
    }
}
