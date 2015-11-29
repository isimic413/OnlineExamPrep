using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IQuestionTypeRepository
    {
        Task<IQuestionType> GetSingleAsync(string questionTypeId);
        Task<List<IQuestionType>> GetCollectionAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IQuestionType questionType);
        Task<int> UpdateAsync(IQuestionType questionType);
        Task<int> DeleteAsync(string questionTypeId);
    }
}
