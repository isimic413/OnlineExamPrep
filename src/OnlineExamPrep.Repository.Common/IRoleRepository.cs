using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IRoleRepository
    {
        Task<IRole> GetAsync(string roleId);
        Task<List<IRole>> GetAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IRole role);
        Task<int> AddForInsert(IRole role);
        Task<int> UpdateAsync(IRole role);
        Task<int> DeleteAsync(string roleId);
    }
}
