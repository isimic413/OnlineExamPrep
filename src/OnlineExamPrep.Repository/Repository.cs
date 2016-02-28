using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Repository.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class Repository : IRepository
    {
        protected IOnlineExamContext dbContext { get; private set; }
        protected IUnitOfWorkFactory unitOfWorkFactory { get; private set; }

        public Repository(IOnlineExamContext dbContext, IUnitOfWorkFactory unitOfWorkFactory)
        {
            this.dbContext = dbContext;
            this.unitOfWorkFactory = unitOfWorkFactory;
        }

        public IUnitOfWork GetUnitOfWork()
        {
            return unitOfWorkFactory.CreateUnitOfWork();
        }
        
        public IQueryable<T> FetchCollection<T>() where T : class
        {
            return dbContext.Set<T>();//.AsNoTracking();
        }

        public Task<T> FetchEntityAsync<T>(string id) where T : class
        {
            return dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertEntityAsync<T>(T entity) where T : class
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
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateEntityAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = dbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;

            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEntityAsync<T>(T entity) where T : class
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
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteEntityAsync<T>(string id) where T : class
        {
            var entity = await FetchEntityAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified id not found.");
            }
            return await DeleteEntityAsync<T>(entity);
        }
    }
}
