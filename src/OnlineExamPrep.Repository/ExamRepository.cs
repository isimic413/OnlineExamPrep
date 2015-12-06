using OnlineExamPrep.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class ExamRepository : IExamRepository
    {
        protected IRepository repository { get; private set; }

        public ExamRepository(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
