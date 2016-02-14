using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Fields;
using OnlineExamPrep.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        protected IRepository repository { get; private set; }

        public QuestionRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return repository.GetUnitOfWork();
        }

        public async Task<List<IQuestion>> GetPageAsync(PagingParams pagingParams)
        {
            var questions = repository.FetchCollection<QuestionEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : String.Format("{0},{1}", QuestionFields.QuestionTypeId, QuestionFields.Id));
            if (pagingParams.PageSize > 0)
            {
                questions.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            questions.Include(question => question.QuestionType)
                .Include(question => question.AnswerChoices)
                .Include(question => question.ExamQuestions.Select(eq => eq.Exam.TestingArea));

            return Mapper.Map<List<IQuestion>>(await questions.ToListAsync());
        }

        public Task<int> AddForInsertAsync(IUnitOfWork unitOfWork, IQuestion questionModel)
        {
            return unitOfWork.AddForInsertAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(questionModel));
        }
    }
}
