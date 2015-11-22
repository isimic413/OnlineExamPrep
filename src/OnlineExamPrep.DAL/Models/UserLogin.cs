using System;
using System.Collections.Generic;

namespace OnlineExamPrep.DAL.Models
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
