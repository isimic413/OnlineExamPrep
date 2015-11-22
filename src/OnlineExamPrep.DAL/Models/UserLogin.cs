using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class UserLoginEntity
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
