using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class QuestionService : IQuestionService
    {
        protected IQuestionRepository questionRepository { get; private set; }
        protected IAnswerChoiceRepository answerChoiceRepository { get; private set; }

        public QuestionService(IQuestionRepository questionRepository, IAnswerChoiceRepository answerChoiceRepository)
        {
            this.questionRepository = questionRepository;
            this.answerChoiceRepository = answerChoiceRepository;
        }
    }
}
