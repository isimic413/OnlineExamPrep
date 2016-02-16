using OnlineExamPrep.Models.Common;

namespace OnlineExamPrep.Models.ParamsModel
{
    public class UserLoginParams : OnlineExamPrep.Models.Common.ParamsModel.IUserLoginParams
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public IUser User { get; set; }
    }
}
