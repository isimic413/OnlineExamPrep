namespace OnlineExamPrep.Models.Common
{
    public interface IExamQuestion
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        string ExamId { get; set; }
        int Number { get; set; }
        IExam Exam { get; set; }
        IQuestion Question { get; set; }
    }
}
