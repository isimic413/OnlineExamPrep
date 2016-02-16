using System;

namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IUserExamResultParams
    {
        string Id { get; set; }
        string UserId { get; set; }
        string ExamId { get; set; }
        int DurationInMinutes { get; set; }
        int Points { get; set; }
        int CorrectAnswers { get; set; }
        DateTime TimeTaken { get; set; }
        IExam Exam { get; set; }
        IUser User { get; set; }
    }
}
