using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface ITestingAreaService
    {
        Task<ITestingArea> GetSingleAsync(string testingAreaId);
        Task<List<ITestingArea>> GetCollectionAsync(PagingParams pagingParams);
        Task<int> InsertAsync(ITestingArea testingArea);
        Task<int> UpdateAsync(ITestingArea testingArea);
        Task<int> DeleteAsync(string testingAreaId);
    }
}
