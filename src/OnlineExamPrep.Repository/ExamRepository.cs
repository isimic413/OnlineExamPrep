using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using OnlineExamPrep.Models.Fields;
using OnlineExamPrep.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
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

        public async Task<List<IExamParams>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams)
        {
            var exams = repository.FetchCollection<ExamEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : String.Format("{0},{1},{2}", ExamFields.TestingAreaId, ExamFields.Year, ExamFields.Id));
            if (pagingParams.PageSize > 0)
            {
                exams.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            exams.Include(exam => exam.TestingArea)
                .Include(exam => exam.ExamQuestions.Select(eq => eq.Question));
            return Mapper.Map<List<IExamParams>>(await exams.ToListAsync());
        }

        public async Task<IExamParams> GetExamForUpdateAsync(string examId)
        {
            var examEntity = await repository.FetchCollection<ExamEntity>()
                .Where(exam => exam.Id == examId)
                .Include(exam => exam.TestingArea)
                .SingleOrDefaultAsync();

            return Mapper.Map<IExamParams>(examEntity);
        }

        public async Task<int> InsertAsync(IExam exam)
        {
            return await repository.InsertEntityAsync<ExamEntity>(Mapper.Map<ExamEntity>(exam));
        }

        public async Task<int> UpdateAsync(IExam exam)
        {
            return await repository.UpdateEntityAsync<ExamEntity>(Mapper.Map<ExamEntity>(exam));
        }

        public async Task<int> DeleteAsync(string examId)
        {
            return await repository.DeleteEntityAsync<ExamEntity>(examId);
        }

        public Task<int> AddExamQuestionForInsert(IUnitOfWork unitOfWork, IExamQuestion examQuestion)
        {
            return unitOfWork.AddForInsertAsync<ExamQuestionEntity>(Mapper.Map<ExamQuestionEntity>(examQuestion));
        }

        public Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion)
        {
            return unitOfWork.AddForDeleteAsync<ExamQuestionEntity>(Mapper.Map<ExamQuestionEntity>(examQuestion));
        }

        public Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, string examQuestionId)
        {
            return unitOfWork.AddForDeleteAsync<ExamQuestionEntity>(examQuestionId);
        }

        public async Task<int> GetNumberOfQuestionsAsync(string examId)
        {
            return (await repository.FetchCollection<ExamQuestionEntity>()
                .Where(eq => eq.ExamId == examId)
                .ToListAsync()).Count;
        }
    }
}
