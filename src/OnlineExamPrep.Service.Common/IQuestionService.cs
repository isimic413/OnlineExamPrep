using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IQuestionService
    {
        Task<List<dynamic>> GetPageAsync(PagingParams pagingParams);
        Task<int> InsertAsync(IQuestion question, IAnswerChoice[] answerChoices, string examId);
    }
}
