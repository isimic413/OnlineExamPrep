namespace OnlineExamPrep.Models.Common
{
    public interface IUserLogin
    {
        string LoginProvider { get; set; }
        string ProviderKey { get; set; }
        string UserId { get; set; }
        IUser User { get; set; }
    }
}
