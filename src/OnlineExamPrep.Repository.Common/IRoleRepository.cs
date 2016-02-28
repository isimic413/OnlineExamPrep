using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IRoleRepository
    {
        Task<IRole> GetSingleAsync(string roleId);
        Task<IRole> GetByUserId(string userId);
        Task<List<IRole>> GetCollectionAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IRole role);
        Task<int> AddForInsert(IRole role);
        Task<int> UpdateAsync(IRole role);
        Task<int> DeleteAsync(string roleId);
    }
}
