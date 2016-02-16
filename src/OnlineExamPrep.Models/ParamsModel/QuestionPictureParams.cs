using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class QuestionPictureParams : OnlineExamPrep.Models.Common.ParamsModel.IQuestionPictureParams
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public byte[] Image { get; set; }
        public IQuestion Question { get; set; }
    }
}
