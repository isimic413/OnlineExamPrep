using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IAnswerChoiceService
    {
        Task<IAnswerChoice> GetSingleAsync(string answerChoiceId);
        Task<List<IAnswerChoice>> GetCorrectAnswersFroQuestionIdAsync(string questionId);
        Task<List<IAnswerChoice>> GetCollectionAsync(PagingParams pagingParams);
        Task<List<IAnswerChoice>> GetChoicesByQuestionIdAsync(string questionId);
        Task<int> InsertAsync(IAnswerChoice answerChoice);
        Task<int> UpdateAsync(IAnswerChoice answerChoice);
        Task<int> DeleteAsync(string answerChoiceId);
        
        Task<int> InsertPictureAsync(IAnswerChoicePicture answerChoicePicture);
        Task<int> UpdatePictureAsync(IAnswerChoicePicture answerChoicePicture);
        Task<int> DeletePictureAsync(string answerChoicePictureId);
    }
}
