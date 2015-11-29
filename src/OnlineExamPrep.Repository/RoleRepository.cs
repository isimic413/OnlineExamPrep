using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.DAL.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Fields;
using OnlineExamPrep.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository
{
    public class RoleRepository : IRoleRepository
    {
        protected IRepository repository { get; private set; }

        public RoleRepository(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IRole> GetSingleAsync(string roleId)
        {
            return Mapper.Map<IRole>(await repository.FetchEntityAsync<RoleEntity>(roleId));
        }

        public async Task<List<IRole>> GetCollectionAsync(PagingParams pagingParams)
        {
            var roles = repository.FetchCollection<RoleEntity>()
                .OrderBy(!String.IsNullOrEmpty(pagingParams.SortByField) ? pagingParams.SortByField : RoleFields.Name);
            if (pagingParams.PageSize > 0)
            {
                roles.Skip((pagingParams.PageNumber - 1) * pagingParams.PageSize)
                    .Take(pagingParams.PageSize);
            }
            return Mapper.Map<List<IRole>>(await roles.ToListAsync());
        }

        public async Task<int> InsertAsync(IRole role)
        {
            return await repository.InsertEntityAsync<RoleEntity>(Mapper.Map<RoleEntity>(role));
        }

        public Task<int> AddForInsert(IRole role)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(IRole role)
        {
            return await repository.UpdateEntityAsync<RoleEntity>(Mapper.Map<RoleEntity>(role));
        }

        public async Task<int> DeleteAsync(string roleId)
        {
            return await repository.DeleteEntityAsync<RoleEntity>(roleId);
        }
    }
}
