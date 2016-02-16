using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IQuestionRepository
    {
        IUnitOfWork GetUnitOfWork();
        Task<List<IQuestionParams>> GetPageAsync(PagingParams pagingParams);
        Task<IQuestionParams> GetQuestionWithChoicesAndPicuresAsync(string questionId);
        Task<int> DeleteAsync(string questionId);
        Task<int> AddForInsertAsync(IUnitOfWork unitOfWork, IQuestion questionModel);
    }
}
