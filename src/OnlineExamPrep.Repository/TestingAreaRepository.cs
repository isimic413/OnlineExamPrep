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
    public class TestingAreaRepository : ITestingAreaRepository
    {
        protected IRepository repository { get; private set; }

        public TestingAreaRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ITestingArea> GetSingleAsync(string testingAreaId)
        {
            return Mapper.Map<ITestingArea>(await repository.FetchEntityAsync<TestingAreaEntity>(testingAreaId));
        }

        public async Task<List<ITestingArea>> GetCollectionAsync(PagingParams pagingParams)
        {
            var testingAreas = repository.FetchCollection<TestingAreaEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : TestingAreaFields.Title);
            if (pagingParams.PageSize > 0)
            {
                testingAreas.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<ITestingArea>>(await testingAreas.ToListAsync());
        }

        public async Task<int> InsertAsync(ITestingArea testingArea)
        {
            return await repository.InsertEntityAsync<TestingAreaEntity>(Mapper.Map<TestingAreaEntity>(testingArea));
        }

        public async Task<int> UpdateAsync(ITestingArea testingArea)
        {
            return await repository.UpdateEntityAsync<TestingAreaEntity>(Mapper.Map<TestingAreaEntity>(testingArea));
        }

        public async Task<int> DeleteAsync(string testingAreaId)
        {
            return await repository.DeleteEntityAsync<TestingAreaEntity>(testingAreaId);
        }
    }
}
