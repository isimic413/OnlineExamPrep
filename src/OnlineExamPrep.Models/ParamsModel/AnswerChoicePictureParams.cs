using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class AnswerChoicePictureParams : OnlineExamPrep.Models.Common.ParamsModel.IAnswerChoicePictureParams
    {
        public string Id { get; set; }
        public string AnswerChoiceId { get; set; }
        public byte[] Image { get; set; }
        public IAnswerChoice AnswerChoice { get; set; }
    }
}
