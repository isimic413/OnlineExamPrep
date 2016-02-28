using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IUserRepository
    {
        Task<IUser> GetAsync(string userId);
        Task<List<IUser>> GetAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IUser user);
        Task<int> UpdateAsync(IUser user);
        Task<int> DeleteAsync(string userId);
    }
}
