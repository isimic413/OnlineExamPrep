using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class AnswerStepPictureParams : OnlineExamPrep.Models.Common.ParamsModel.IAnswerStepPictureParams
    {
        public string Id { get; set; }
        public string AnswerStepId { get; set; }
        public byte[] Image { get; set; }
        public IAnswerStep AnswerStep { get; set; }
    }
}
