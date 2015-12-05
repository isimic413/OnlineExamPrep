using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IQuestionRepository
    {
        IUnitOfWork CreateUnitOfWork();

        Task<IQuestion> GetSingleAsync(string questionId);
        Task<IQuestion> GetSingleWithPicturesAsync(string questionId);
        Task<IQuestion> GetSingleWithAnswerChoicesAsync(string questionId);
        Task<IQuestion> GetSingleWithStepsAsync(string questionId);
        Task<List<IQuestion>> GetCollectionAsync(PagingParams pagingParams);
        Task<List<IQuestion>> GetCollectionByTypeAsync(PagingParams pagingParams, string questionTypeId);
        Task<List<IQuestion>> GetCollectionByTestingAreaAsync(PagingParams pagingParams, string testingAreaId);
        Task<int> InsertAsync(IQuestion question);
        Task<int> UpdateAsync(IQuestion question);
        Task<int> DeleteAsync(string questionId);
        Task<int> AddToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestion question);
        Task<int> AddToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestion question);
        Task<int> AddToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionId);

        Task<int> InsertPictureAsync(IQuestionPicture questionPicture);
        Task<int> UpdatePictureAsync(IQuestionPicture questionPicture);
        Task<int> DeletePictureAsync(string questionPictureId);
        Task<int> AddPictureToUowForInsertAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture);
        Task<int> AddPictureToUowForUpdateAsync(IUnitOfWork unitOfWork, IQuestionPicture questionPicture);
        Task<int> AddPictureToUowForDeleteAsync(IUnitOfWork unitOfWork, string questionPictureId);
    }
}
