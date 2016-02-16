namespace OnlineExamPrep.Models.Common
{
    public interface IAnswerStepPicture
    {
        string Id { get; set; }
        string AnswerStepId { get; set; }
        byte[] Image { get; set; }
    }
}
