using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class AnswerStepPicture : IAnswerStepPicture
    {
        public string Id { get; set; }
        public string AnswerStepId { get; set; }
        public byte[] Image { get; set; }
    }
}
