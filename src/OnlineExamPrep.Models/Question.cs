using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models
{
    public class Question : IQuestion
    {
        public string Id { get; set; }
        public string QuestionTypeId { get; set; }
        public string Text { get; set; }
    }
}
