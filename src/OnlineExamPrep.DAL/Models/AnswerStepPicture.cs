using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class AnswerStepPictureEntity
    {
        public string Id { get; set; }
        public string AnswerStepId { get; set; }
        public byte[] Image { get; set; }
        public virtual AnswerStepEntity AnswerStep { get; set; }
    }
}
