using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Repository.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineExamPrep.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected IOnlineExamContext dbContext { get; private set; }

        public UnitOfWork(IOnlineExamContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<int> AddForInsertAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                dbContext.Set<T>().Add(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> AddForUpdateAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return Task.FromResult(1);
        }

        public Task<int> AddForDeleteAsync<T>(T entity) where T : class
        {

            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                dbContext.Set<T>().Attach(entity);
                dbContext.Set<T>().Remove(entity);
            }
            return Task.FromResult(1);
        }

        public Task<int> AddForDeleteAsync<T>(string id) where T : class
        {
            var entity = dbContext.Set<T>().Find(id);
            if (entity == null)
            {
                return Task.FromResult(0);
            }
            return AddForDeleteAsync<T>(entity);
        }

        public async Task<int> CommitAsync()
        {
            int result = 0;
            using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                result = await dbContext.SaveChangesAsync();
                scope.Complete();
            }
            return result;
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
