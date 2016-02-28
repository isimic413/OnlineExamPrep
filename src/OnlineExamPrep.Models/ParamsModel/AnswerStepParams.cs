using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class AnswerStepParams : OnlineExamPrep.Models.Common.ParamsModel.IAnswerStepParams
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public byte Number { get; set; }
        public byte Points { get; set; }
        public IQuestion Question { get; set; }
        public ICollection<IAnswerStepPicture> AnswerStepPictures { get; set; }
    }
}
