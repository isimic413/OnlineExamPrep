using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class RoleService : IRoleService
    {
        protected IRoleRepository roleRepository { get; private set; }

        public RoleService(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public Task<IRole> GetSingleAsync(string roleId)
        {
            return roleRepository.GetSingleAsync(roleId);
        }

        public Task<List<IRole>> GetCollectionAsync(PagingParams pagingParams)
        {
            if (pagingParams == null)
            {
                pagingParams = new PagingParams();
            }
            return roleRepository.GetCollectionAsync(pagingParams);
        }

        public Task<int> InsertAsync(IRole role)
        {
            role.Id = Guid.NewGuid().ToString();
            return roleRepository.InsertAsync(role);
        }

        public Task<int> UpdateAsync(IRole role)
        {
            if (String.IsNullOrEmpty(role.Id))
            {
                throw new ArgumentNullException("Id");
            }
            return roleRepository.UpdateAsync(role);
        }

        public Task<int> DeleteAsync(string roleId)
        {
            return roleRepository.DeleteAsync(roleId);
        }
    }
}
