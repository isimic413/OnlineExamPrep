using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System.Collections.Generic;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class QuestionParams : IQuestionParams
    {
        public string Id { get; set; }
        public string QuestionTypeId { get; set; }
        public string Text { get; set; }
        public ICollection<IAnswerChoice> AnswerChoices { get; set; }
        public ICollection<IAnswerStep> AnswerSteps { get; set; }
        public ICollection<IExamQuestionParams> ExamQuestions { get; set; }
        public IQuestionType QuestionType { get; set; }
        public ICollection<IQuestionPicture> QuestionPictures { get; set; }
    }
}
