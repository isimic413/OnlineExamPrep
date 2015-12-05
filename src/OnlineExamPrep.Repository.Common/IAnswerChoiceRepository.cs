using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IAnswerChoiceRepository
    {
        IUnitOfWork CreateUnitOfWork();

        Task<IAnswerChoice> GetSingleAsync(string answerChoiceId);
        Task<List<IAnswerChoice>> GetCorrectAnswersFroQuestionIdAsync(string questionId);
        Task<List<IAnswerChoice>> GetCollectionAsync(PagingParams pagingParams);
        Task<List<IAnswerChoice>> GetChoicesByQuestionIdAsync(string questionId);
        Task<int> InsertAsync(IAnswerChoice answerChoice);
        Task<int> UpdateAsync(IAnswerChoice answerChoice);
        Task<int> DeleteAsync(string answerChoiceId);
        Task<int> AddToUowForInsertAsync(IUnitOfWork unitOfWork, IAnswerChoice answerChoice);
        Task<int> AddToUowForUpdateAsync(IUnitOfWork unitOfWork, IAnswerChoice answerChoice);
        Task<int> AddToUowForDeleteAsync(IUnitOfWork unitOfWork, string answerChoiceId);

        Task<int> InsertPictureAsync(IAnswerChoicePicture answerChoicePicture);
        Task<int> UpdatePictureAsync(IAnswerChoicePicture answerChoicePicture);
        Task<int> DeletePictureAsync(string answerChoicePictureId);
        Task<int> AddPictureToUowForInsertAsync(IUnitOfWork unitOfWork, IAnswerChoicePicture answerChoicePicture);
        Task<int> AddPictureToUowForUpdateAsync(IUnitOfWork unitOfWork, IAnswerChoicePicture answerChoicePicture);
        Task<int> AddPictureToUowForDeleteAsync(IUnitOfWork unitOfWork, string answerChoicePictureId);
    }
}
