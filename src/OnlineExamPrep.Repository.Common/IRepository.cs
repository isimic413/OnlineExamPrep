using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IRepository
    {
        IUnitOfWork GetUnitOfWork();
        IQueryable<T> FetchCollection<T>() where T : class;
        Task<T> FetchEntityAsync<T>(string id) where T : class;
        Task<int> InsertEntityAsync<T>(T entity) where T : class;
        Task<int> UpdateEntityAsync<T>(T entity) where T : class;
        Task<int> DeleteEntityAsync<T>(T entity) where T : class;
        Task<int> DeleteEntityAsync<T>(string id) where T : class;
    }
}
