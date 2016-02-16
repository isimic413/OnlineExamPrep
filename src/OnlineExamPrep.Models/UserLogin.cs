using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class UserLogin : IUserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
    }
}
