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
        Task<int> DeleteAsync(string examId);
        Task<int> AddExamQuestionForInsert(IUnitOfWork unitOfWork, IExamQuestion examQuestion);
        Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, IExamQuestion examQuestion);
        Task<int> AddExamQuestionForDeleteAsync(IUnitOfWork unitOfWork, string examQuestionId);
        Task<int> GetNumberOfQuestionsAsync(string examId);
    }
}
