using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class TestingAreaService : ITestingAreaService
    {
        protected ITestingAreaRepository testingAreaRepository { get; private set; }

        public TestingAreaService(ITestingAreaRepository testingAreaRepository)
        {
            this.testingAreaRepository = testingAreaRepository;
        }

        public Task<ITestingArea> GetSingleAsync(string testingAreaId)
        {
            return testingAreaRepository.GetSingleAsync(testingAreaId);
        }

        public Task<List<ITestingArea>> GetCollectionAsync(PagingParams pagingParams)
        {
            if (pagingParams == null)
            {
                pagingParams = new PagingParams();
            }
            return testingAreaRepository.GetCollectionAsync(pagingParams);
        }

        public Task<int> InsertAsync(ITestingArea testingArea)
        {
            testingArea.Id = Guid.NewGuid().ToString();
            return testingAreaRepository.InsertAsync(testingArea);
        }

        public Task<int> UpdateAsync(ITestingArea testingArea)
        {
            if (String.IsNullOrEmpty(testingArea.Id))
            {
                throw new ArgumentNullException("Id");
            }
            return testingAreaRepository.UpdateAsync(testingArea);
        }

        public Task<int> DeleteAsync(string testingAreaId)
        {
            return testingAreaRepository.DeleteAsync(testingAreaId);
        }
    }
}
