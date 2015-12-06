using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class AnswerChoiceService : IAnswerChoiceService
    {
        protected IAnswerChoiceRepository answerChoiceRepository { get; private set; }

        public AnswerChoiceService(IAnswerChoiceRepository answerChoiceRepository)
        {
            this.answerChoiceRepository = answerChoiceRepository;
        }
    }
}
