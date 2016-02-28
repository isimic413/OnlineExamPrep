namespace OnlineExamPrep.Models.Common
{
    public interface IAnswerChoicePicture
    {
        string Id { get; set; }
        string AnswerChoiceId { get; set; }
        byte[] Image { get; set; }
    }
}
