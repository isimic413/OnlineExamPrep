using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Fields;
using OnlineExamPrep.Repository.Common;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        protected IRepository repository { get; private set; }

        public QuestionTypeRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IQuestionType> GetSingleAsync(string questionTypeId)
        {
            return Mapper.Map<IQuestionType>(await repository.FetchEntityAsync<QuestionTypeEntity>(questionTypeId));
        }

        public async Task<List<IQuestionType>> GetCollectionAsync(PagingParams pagingParams)
        {
            var questionTypes = repository.FetchCollection<QuestionTypeEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : QuestionTypeFields.Title);
            if (pagingParams.PageSize > 0)
            {
                questionTypes.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IQuestionType>>(await questionTypes.ToListAsync());
        }

        public async Task<int> InsertAsync(IQuestionType questionType)
        {
            return await repository.InsertEntityAsync<QuestionTypeEntity>(Mapper.Map<QuestionTypeEntity>(questionType));
        }

        public async Task<int> UpdateAsync(IQuestionType questionType)
        {
            return await repository.UpdateEntityAsync<QuestionTypeEntity>(Mapper.Map<QuestionTypeEntity>(questionType));
        }

        public async Task<int> DeleteAsync(string questionTypeId)
        {
            return await repository.DeleteEntityAsync<QuestionTypeEntity>(questionTypeId);
        }
    }
}
