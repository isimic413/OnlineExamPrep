using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class UserClaimParams : OnlineExamPrep.Models.Common.ParamsModel.IUserClaimParams
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public IUser User { get; set; }
    }
}
