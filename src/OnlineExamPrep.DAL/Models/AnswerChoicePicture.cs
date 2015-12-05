using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class AnswerChoicePictureEntity
    {
        public string Id { get; set; }
        public string AnswerChoiceId { get; set; }
        public byte[] Image { get; set; }
        public virtual AnswerChoiceEntity AnswerChoice { get; set; }
    }
}
