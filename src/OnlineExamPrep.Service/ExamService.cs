using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class ExamService : IExamService
    {
        protected IExamRepository examRepository { get; private set; }

        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }
    }
}
