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

        public IUnitOfWork CreateUnitOfWork()
        {
            return repository.GetUnitOfWork();
        }

        public async Task<IQuestion> GetSingleAsync(string questionId)
        {
            return Mapper.Map<IQuestion>(await repository.FetchEntityAsync<QuestionEntity>(questionId));
        }

        public async Task<IQuestion> GetSingleWithPicturesAsync(string questionId)
        {
            var question = repository.FetchCollection<QuestionEntity>()
                .Where(q => q.Id == questionId)
                .Include(q => q.QuestionPictures);
            return Mapper.Map<IQuestion>(await question.FirstOrDefaultAsync());
        }

        public async Task<IQuestion> GetSingleWithAnswerChoicesAsync(string questionId)
        {
            var question = repository.FetchCollection<QuestionEntity>()
                .Where(q => q.Id == questionId)
                .Include(q => q.QuestionPictures)
                .Include(q => q.AnswerChoices.Select(choice => choice.AnswerChoicePictures));
            return Mapper.Map<IQuestion>(await question.FirstOrDefaultAsync());
        }

        public async Task<IQuestion> GetSingleWithStepsAsync(string questionId)
        {
            var question = repository.FetchCollection<QuestionEntity>()
                .Where(q => q.Id == questionId)
                .Include(q => q.AnswerSteps.Select(step => step.AnswerStepPictures));
            return Mapper.Map<IQuestion>(await question.FirstOrDefaultAsync());
        }

        public async Task<List<IQuestion>> GetCollectionAsync(PagingParams pagingParams)
        {
            var questions = repository.FetchCollection<QuestionEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : QuestionFields.Id);
            if (pagingParams.PageSize > 0)
            {
                questions.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IQuestion>>(await questions.ToListAsync());
        }

        public async Task<List<IQuestion>> GetCollectionByTypeAsync(PagingParams pagingParams, string questionTypeId)
        {
            var questions = repository.FetchCollection<QuestionEntity>()
                .Where(question => question.QuestionTypeId == questionTypeId)
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : QuestionFields.Id);
            if (pagingParams.PageSize > 0)
            {
                questions.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IQuestion>>(await questions.ToListAsync());
        }

        public async Task<List<IQuestion>> GetCollectionByTestingAreaAsync(PagingParams pagingParams, string testingAreaId)
        {
            var questions = repository.FetchCollection<QuestionEntity>()
                .Where(question => question.TestingAreaId == testingAreaId)
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : QuestionFields.Id);
            if (pagingParams.PageSize > 0)
            {
                questions.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IQuestion>>(await questions.ToListAsync());
        }

        public async Task<int> InsertAsync(IQuestion question)
        {
            return await repository.InsertEntityAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public async Task<int> UpdateAsync(IQuestion question)
        {
            return await repository.UpdateEntityAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public async Task<int> DeleteAsync(string questionId)
        {
            return await repository.DeleteEntityAsync<QuestionEntity>(questionId);
        }

        public async Task<int> AddToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestion question)
        {
            return await unitOfWork.AddForInsertAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public async Task<int> AddToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestion question)
        {
            return await unitOfWork.AddForUpdateAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public async Task<int> AddToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionId)
        {
            return await unitOfWork.AddForDeleteAsync<QuestionEntity>(questionId);
        }

        public async Task<int> InsertPictureAsync(IQuestionPicture questionPicture)
        {
            return await repository.InsertEntityAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public async Task<int> UpdatePictureAsync(IQuestionPicture questionPicture)
        {
            return await repository.UpdateEntityAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public async Task<int> DeletePictureAsync(string questionPictureId)
        {
            return await repository.DeleteEntityAsync<QuestionPictureEntity>(questionPictureId);
        }

        public async Task<int> AddPictureToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture)
        {
            return await unitOfWork.AddForInsertAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public async Task<int> AddPictureToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture)
        {
            return await unitOfWork.AddForUpdateAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public async Task<int> AddPictureToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionPictureId)
        {
            return await unitOfWork.AddForDeleteAsync<QuestionPictureEntity>(questionPictureId);
        }
    }
}
