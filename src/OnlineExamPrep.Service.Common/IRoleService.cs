using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IRoleService
    {
        Task<IRole> GetSingleAsync(string roleId);
        Task<List<IRole>> GetCollectionAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IRole role);
        Task<int> UpdateAsync(IRole role);
        Task<int> DeleteAsync(string roleId);
    }
}
