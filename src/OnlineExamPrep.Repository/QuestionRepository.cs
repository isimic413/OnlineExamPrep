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

        public async Task<IQuestion> GetSingleForUpdateAsync(string questionId)
        {
            var question = repository.FetchCollection<QuestionEntity>()
                .Where(q => q.Id == questionId)
                .Include(q => q.QuestionPictures)
                .Include(q => q.ExamQuestions)
                .Include(q => q.AnswerChoices.Select(choice => choice.AnswerChoicePictures));
            return Mapper.Map<IQuestion>(await question.FirstOrDefaultAsync());
        }

        public Task<IQuestion> GetSingleForDeleteAsync(string questionId)
        {
            return GetSingleForUpdateAsync(questionId);
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
            questions.Include(q => q.QuestionPictures)
                .Include(q => q.QuestionType)
                .Include(q => q.TestingArea);
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

        public Task<int> InsertAsync(IQuestion question)
        {
            return repository.InsertEntityAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public Task<int> UpdateAsync(IQuestion question)
        {
            return repository.UpdateEntityAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public Task<int> DeleteAsync(string questionId)
        {
            return repository.DeleteEntityAsync<QuestionEntity>(questionId);
        }

        public Task<int> AddToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestion question)
        {
            return unitOfWork.AddForInsertAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public Task<int> AddToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestion question)
        {
            return unitOfWork.AddForUpdateAsync<QuestionEntity>(Mapper.Map<QuestionEntity>(question));
        }

        public Task<int> AddToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionId)
        {
            return unitOfWork.AddForDeleteAsync<QuestionEntity>(questionId);
        }

        public Task<int> InsertPictureAsync(IQuestionPicture questionPicture)
        {
            return repository.InsertEntityAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public Task<int> UpdatePictureAsync(IQuestionPicture questionPicture)
        {
            return repository.UpdateEntityAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public Task<int> DeletePictureAsync(string questionPictureId)
        {
            return repository.DeleteEntityAsync<QuestionPictureEntity>(questionPictureId);
        }

        public Task<int> AddPictureToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture)
        {
            return unitOfWork.AddForInsertAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public Task<int> AddPictureToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture)
        {
            return unitOfWork.AddForUpdateAsync<QuestionPictureEntity>(Mapper.Map<QuestionPictureEntity>(questionPicture));
        }

        public Task<int> AddPictureToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionPictureId)
        {
            return unitOfWork.AddForDeleteAsync<QuestionPictureEntity>(questionPictureId);
        }

        public Task<int> AddExamQuestionToUnitOfWorkForInsertAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion)
        {
            return unitOfWork.AddForInsertAsync<ExamQuestionEntity>(Mapper.Map<ExamQuestionEntity>(examQuestion));
        }

        public Task<int> AddExamQuestionToUnitOfWorkForUpdateAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion)
        {
            return unitOfWork.AddForUpdateAsync<ExamQuestionEntity>(Mapper.Map<ExamQuestionEntity>(examQuestion));
        }

        public Task<int> AddExamQuestionToUnitOfWorkForDeleteAsync(IUnitOfWork unitOfWork, string examQuestionId)
        {
            return unitOfWork.AddForDeleteAsync<ExamQuestionEntity>(examQuestionId);
        }
    }
}
