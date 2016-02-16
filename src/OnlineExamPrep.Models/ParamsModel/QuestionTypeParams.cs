using OnlineExamPrep.Models.Common;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class QuestionTypeParams : OnlineExamPrep.Models.Common.ParamsModel.IQuestionTypeParams
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<IQuestion> Questions { get; set; }
    }
}
