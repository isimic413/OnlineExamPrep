using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IExamRepository
    {
        Task<List<IExam>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IExam exam);
    }
}
