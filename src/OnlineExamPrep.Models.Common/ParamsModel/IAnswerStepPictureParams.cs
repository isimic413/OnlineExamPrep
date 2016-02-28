namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IAnswerStepPictureParams
    {
        string Id { get; set; }
        string AnswerStepId { get; set; }
        byte[] Image { get; set; }
        IAnswerStep AnswerStep { get; set; }
    }
}
