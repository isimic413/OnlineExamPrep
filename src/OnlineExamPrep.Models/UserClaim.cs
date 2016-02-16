using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models
{
    public class UserClaim : IUserClaim
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
