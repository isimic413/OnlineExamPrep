using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IUserService
    {
        Task<dynamic> GetApplicationData(string userId);
    }
}
