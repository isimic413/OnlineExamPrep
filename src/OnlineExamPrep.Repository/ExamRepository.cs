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

        public async Task<List<IExam>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams)
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
            return Mapper.Map<List<IExam>>(await exams.ToListAsync());
        }
    }
}
