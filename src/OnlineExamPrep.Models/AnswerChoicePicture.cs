using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class AnswerChoicePicture : IAnswerChoicePicture
    {
        public string Id { get; set; }
        public string AnswerChoiceId { get; set; }
        public byte[] Image { get; set; }
    }
}
