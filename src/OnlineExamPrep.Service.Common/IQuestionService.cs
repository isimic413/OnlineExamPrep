using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IQuestionService
    {
        Task<IQuestion> GetSingleAsync(string questionId);
        Task<IQuestion> GetSingleWithPicturesAsync(string questionId);
        Task<IQuestion> GetSingleWithAnswerChoicesAsync(string questionId);
        Task<IQuestion> GetSingleWithStepsAsync(string questionId);
        Task<List<IQuestion>> GetCollectionAsync(PagingParams pagingParams);
        Task<List<IQuestion>> GetCollectionByTypeAsync(PagingParams pagingParams, string questionTypeId);
        Task<List<IQuestion>> GetCollectionByTestingAreaAsync(PagingParams pagingParams, string testingAreaId);
        Task<int> InsertAsync(IQuestion question, List<IAnswerChoice> answerChoiceList);
        Task<int> UpdateAsync(IQuestion question, List<IAnswerChoice> answerChoiceList);
        Task<int> UpdateAsync(IQuestion question);
        Task<int> DeleteAsync(string questionId);

        Task<int> InsertPictureAsync(IQuestionPicture questionPicture);
        Task<int> UpdatePictureAsync(IQuestionPicture questionPicture);
        Task<int> DeletePictureAsync(string questionPictureId);
    }
}
