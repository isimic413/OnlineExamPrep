using OnlineExamPrep.Models.Common;
using System;
using System.Collections.Generic;

namespace OnlineExamPrep.Models
{
    public class AnswerStep : IAnswerStep
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public byte Number { get; set; }
        public Nullable<byte> Points { get; set; }
        public IQuestion Question { get; set; }
        public ICollection<IAnswerStepPicture> AnswerStepPictures { get; set; }
    }
}
