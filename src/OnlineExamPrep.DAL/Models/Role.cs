using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class RoleEntity
    {
        public RoleEntity()
        {
            this.Users = new List<UserEntity>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
