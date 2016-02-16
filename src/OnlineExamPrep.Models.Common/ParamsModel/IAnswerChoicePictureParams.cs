namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IAnswerChoicePictureParams
    {
        string Id { get; set; }
        string AnswerChoiceId { get; set; }
        byte[] Image { get; set; }
        IAnswerChoice AnswerChoice { get; set; }
    }
}
