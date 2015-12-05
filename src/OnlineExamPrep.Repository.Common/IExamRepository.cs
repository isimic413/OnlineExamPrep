using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IExamRepository
    {
        IUnitOfWork CreateUnitOfWork();
        Task<IExam> GetSingleAsync(string examId);
        Task<IExam> GetSingleWithQuestionPreviewsAsync(string examId);
        Task<IExam> GetSingleWithQuestionsAsync(string examId);
        Task<List<IExam>> GetCollectionAsync(PagingParams pagingParams);
        Task<List<IExam>> GetCollectionByYearAsync(int year);
        Task<List<IExam>> GetCollectionByTestingAreaIdAsync(string testingAreaId);
        Task<List<IExam>> GetCollectionByYearAndTestingAreaIdAsync(int year, string testingAreaId);
        Task<int> InsertAsync(IExam exam);
        Task<int> UpdateAsync(IExam exam);
        Task<int> DeleteAsync(string examId);
    }
}
