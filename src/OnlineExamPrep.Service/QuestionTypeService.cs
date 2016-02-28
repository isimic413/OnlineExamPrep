using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class QuestionTypeService : IQuestionTypeService
    {
        protected IQuestionTypeRepository questionTypeRepository { get; private set; }

        public QuestionTypeService(IQuestionTypeRepository questionTypeRepository)
        {
            this.questionTypeRepository = questionTypeRepository;
        }

        public Task<IQuestionType> GetSingleAsync(string questionTypeId)
        {
            return questionTypeRepository.GetSingleAsync(questionTypeId);
        }

        public Task<List<IQuestionType>> GetCollectionAsync(PagingParams pagingParams)
        {
            if (pagingParams == null)
            {
                pagingParams = new PagingParams();
            }
            return questionTypeRepository.GetCollectionAsync(pagingParams);
        }

        public Task<int> InsertAsync(IQuestionType questionType)
        {
            questionType.Id = Guid.NewGuid().ToString();
            return questionTypeRepository.InsertAsync(questionType);
        }

        public Task<int> UpdateAsync(IQuestionType questionType)
        {
            if (String.IsNullOrEmpty(questionType.Id))
            {
                throw new ArgumentNullException("Id");
            }
            return questionTypeRepository.UpdateAsync(questionType);
        }

        public Task<int> DeleteAsync(string questionTypeId)
        {
            return questionTypeRepository.DeleteAsync(questionTypeId);
        }
    }
}
