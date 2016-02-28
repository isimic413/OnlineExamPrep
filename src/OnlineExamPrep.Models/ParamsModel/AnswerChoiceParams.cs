using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class AnswerChoiceParams : OnlineExamPrep.Models.Common.ParamsModel.IAnswerChoiceParams
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string Text { get; set; }
        public byte Points { get; set; }
        public IQuestion Question { get; set; }
        public ICollection<IAnswerChoicePicture> AnswerChoicePictures { get; set; }
    }
}
