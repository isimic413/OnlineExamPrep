using OnlineExamPrep.Models.Common;
using System;

namespace OnlineExamPrep.Models
{
    public class UserExamResult : IUserExamResult
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ExamId { get; set; }
        public int DurationInMinutes { get; set; }
        public int Points { get; set; }
        public int CorrectAnswers { get; set; }
        public DateTime TimeTaken { get; set; }
    }
}
