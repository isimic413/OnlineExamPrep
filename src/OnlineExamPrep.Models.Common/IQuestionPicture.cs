namespace OnlineExamPrep.Models.Common
{
    public interface IQuestionPicture
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        byte[] Image { get; set; }
    }
}
