using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class Role
    {
        public Role()
        {
            this.Users = new List<User>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
