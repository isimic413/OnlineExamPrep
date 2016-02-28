using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class UserEntity
    {
        public UserEntity()
        {
            this.UserClaims = new List<UserClaimEntity>();
            this.UserLogins = new List<UserLoginEntity>();
            this.UserExamResults = new List<UserExamResultEntity>();
            this.Roles = new List<RoleEntity>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<UserClaimEntity> UserClaims { get; set; }
        public virtual ICollection<UserLoginEntity> UserLogins { get; set; }
        public virtual ICollection<UserExamResultEntity> UserExamResults { get; set; }
        public virtual ICollection<RoleEntity> Roles { get; set; }
    }
}
