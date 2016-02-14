using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IQuestionRepository
    {
        IUnitOfWork GetUnitOfWork();
        Task<List<IQuestion>> GetPageAsync(PagingParams pagingParams);
        Task<int> AddForInsertAsync(IUnitOfWork unitOfWork, IQuestion questionModel);
    }
}
