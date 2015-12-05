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
    public class AnswerChoiceRepository : IAnswerChoiceRepository
    {
        protected IRepository repository { get; private set; }

        public AnswerChoiceRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return repository.GetUnitOfWork();
        }

        public async Task<IAnswerChoice> GetSingleAsync(string answerChoiceId)
        {
            return Mapper.Map<IAnswerChoice>(await repository.FetchEntityAsync<AnswerChoiceEntity>(answerChoiceId));
        }

        public async Task<List<IAnswerChoice>> GetCorrectAnswersFroQuestionIdAsync(string questionId)
        {
            var choices = repository.FetchCollection<AnswerChoiceEntity>()
                .Where(choice => choice.QuestionId == questionId && choice.IsCorrectAnswer);
            return Mapper.Map<List<IAnswerChoice>>(await choices.ToListAsync());
        }

        public async Task<List<IAnswerChoice>> GetCollectionAsync(PagingParams pagingParams)
        {
            var choices = repository.FetchCollection<AnswerChoiceEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : AnswerChoiceFields.Id);
            if (pagingParams.PageSize > 0)
            {
                choices.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IAnswerChoice>>(await choices.ToListAsync());
        }

        public async Task<List<IAnswerChoice>> GetChoicesByQuestionIdAsync(string questionId)
        {
            var choices = repository.FetchCollection<AnswerChoiceEntity>()
                .Where(choice => choice.QuestionId == questionId);
            return Mapper.Map<List<IAnswerChoice>>(await choices.ToListAsync());
        }

        public async Task<int> InsertAsync(IAnswerChoice answerChoice)
        {
            return await repository.InsertEntityAsync<AnswerChoiceEntity>(Mapper.Map<AnswerChoiceEntity>(answerChoice));
        }

        public async Task<int> UpdateAsync(IAnswerChoice answerChoice)
        {
            return await repository.UpdateEntityAsync<AnswerChoiceEntity>(Mapper.Map<AnswerChoiceEntity>(answerChoice));
        }

        public async Task<int> DeleteAsync(string answerChoiceId)
        {
            return await repository.DeleteEntityAsync<AnswerChoiceEntity>(answerChoiceId);
        }

        public async Task<int> AddToUowForInsertAsync(IUnitOfWork unitOfWork, IAnswerChoice answerChoice)
        {
            return await unitOfWork.AddForInsertAsync<AnswerChoiceEntity>(Mapper.Map<AnswerChoiceEntity>(answerChoice));
        }

        public async Task<int> AddToUowForUpdateAsync(IUnitOfWork unitOfWork, IAnswerChoice answerChoice)
        {
            return await unitOfWork.AddForUpdateAsync<AnswerChoiceEntity>(Mapper.Map<AnswerChoiceEntity>(answerChoice));
        }

        public async Task<int> AddToUowForDeleteAsync(IUnitOfWork unitOfWork, string answerChoiceId)
        {
            return await unitOfWork.AddForDeleteAsync<AnswerChoiceEntity>(answerChoiceId);
        }

        public async Task<int> InsertPictureAsync(IAnswerChoicePicture answerChoicePicture)
        {
            return await repository.InsertEntityAsync<AnswerChoicePictureEntity>(Mapper.Map<AnswerChoicePictureEntity>(answerChoicePicture));
        }

        public async Task<int> UpdatePictureAsync(IAnswerChoicePicture answerChoicePicture)
        {
            return await repository.UpdateEntityAsync<AnswerChoicePictureEntity>(Mapper.Map<AnswerChoicePictureEntity>(answerChoicePicture));
        }

        public async Task<int> DeletePictureAsync(string answerChoicePictureId)
        {
            return await repository.DeleteEntityAsync<AnswerChoicePictureEntity>(answerChoicePictureId);
        }

        public async Task<int> AddPictureToUowForInsertAsync(IUnitOfWork unitOfWork, IAnswerChoicePicture answerChoicePicture)
        {
            return await unitOfWork.AddForInsertAsync<AnswerChoicePictureEntity>(Mapper.Map<AnswerChoicePictureEntity>(answerChoicePicture));
        }

        public async Task<int> AddPictureToUowForUpdateAsync(IUnitOfWork unitOfWork, IAnswerChoicePicture answerChoicePicture)
        {
            return await unitOfWork.AddForUpdateAsync<AnswerChoicePictureEntity>(Mapper.Map<AnswerChoicePictureEntity>(answerChoicePicture));
        }

        public async Task<int> AddPictureToUowForDeleteAsync(IUnitOfWork unitOfWork, string answerChoicePictureId)
        {
            return await unitOfWork.AddForDeleteAsync<AnswerChoicePictureEntity>(answerChoicePictureId);
        }
    }
}
