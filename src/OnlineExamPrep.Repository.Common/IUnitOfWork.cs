using System;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> AddForInsertAsync<T>(T entity) where T : class;
        Task<int> AddForUpdateAsync<T>(T entity) where T : class;
        Task<int> AddForDeleteAsync<T>(T entity) where T : class;
        Task<int> AddForDeleteAsync<T>(string id) where T : class;
        Task<int> CommitAsync();
    }
}
