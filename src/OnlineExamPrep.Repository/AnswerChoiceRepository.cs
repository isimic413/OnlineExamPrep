using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class AnswerChoiceRepository : IAnswerChoiceRepository
    {
        protected IRepository repository { get; private set; }

        public AnswerChoiceRepository(IRepository repository)
        {
            this.repository = repository;
        }
    }
}
