using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class QuestionPictureEntity
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public byte[] Image { get; set; }
        public virtual QuestionEntity Question { get; set; }
    }
}
