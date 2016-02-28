using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class UserClaimEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
