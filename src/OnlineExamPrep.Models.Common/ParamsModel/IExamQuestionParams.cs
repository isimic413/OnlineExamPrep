namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IExamQuestionParams
    {
        string Id { get; set; }
        string QuestionId { get; set; }
        string ExamId { get; set; }
        int Number { get; set; }
        ITestingArea TestingArea { get; set; }
        IExam Exam { get; set; }
        IQuestion Question { get; set; }
    }
}
