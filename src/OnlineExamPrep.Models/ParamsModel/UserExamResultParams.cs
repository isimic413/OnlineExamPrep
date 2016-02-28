using OnlineExamPrep.Models.Common;
using System;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class UserExamResultParams : OnlineExamPrep.Models.Common.ParamsModel.IUserExamResultParams
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ExamId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Points { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime TimeTaken { get; set; }
        public IExam Exam { get; set; }
        public IUser User { get; set; }
    }
}
