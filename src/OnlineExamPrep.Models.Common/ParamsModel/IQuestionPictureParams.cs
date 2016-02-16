namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IQuestionPictureParams
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        byte[] Image { get; set; }
        IQuestion Question { get; set; }
    }
}
