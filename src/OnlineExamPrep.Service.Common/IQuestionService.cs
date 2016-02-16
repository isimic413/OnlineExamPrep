using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IQuestionService
    {
        Task<List<dynamic>> GetPageAsync(PagingParams pagingParams);
        Task<IQuestionParams> GetQuestionForUpdateAsync(string questionId);
        Task<int> UpdateQuestionAsync(IQuestion question, IAnswerChoice[] choices);
        Task<int> InsertAsync(IQuestion question, IAnswerChoice[] answerChoices, string examId);
        Task<int> DeleteQuestionAsync(string questionId);
    }
}
