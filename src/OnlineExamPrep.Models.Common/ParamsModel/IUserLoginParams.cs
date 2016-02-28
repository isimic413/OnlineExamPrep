namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IUserLoginParams
    {
        string LoginProvider { get; set; }
        string ProviderKey { get; set; }
        string UserId { get; set; }
        IUser User { get; set; }
    }
}
