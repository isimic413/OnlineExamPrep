namespace OnlineExamPrep.Models.Common.ParamsModel
{
    public interface IUserClaimParams
    {
        int Id { get; set; }
        string UserId { get; set; }
        string ClaimType { get; set; }
        string ClaimValue { get; set; }
        IUser User { get; set; }
    }
}
