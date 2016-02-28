using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class QuestionPicture : IQuestionPicture
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public byte[] Image { get; set; }
    }
}
