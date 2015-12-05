using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Repository.Common;
using OnlineExamPrep.Service.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service
{
    public class AnswerChoiceService : IAnswerChoiceService
    {
        protected IAnswerChoiceRepository answerChoiceRepository { get; private set; }

        public AnswerChoiceService(IAnswerChoiceRepository answerChoiceRepository)
        {
            this.answerChoiceRepository = answerChoiceRepository;
        }

        public Task<IAnswerChoice> GetSingleAsync(string answerChoiceId)
        {
            return answerChoiceRepository.GetSingleAsync(answerChoiceId);
        }

        public Task<List<IAnswerChoice>> GetCorrectAnswersFroQuestionIdAsync(string questionId)
        {
            return answerChoiceRepository.GetCorrectAnswersFroQuestionIdAsync(questionId);
        }

        public Task<List<IAnswerChoice>> GetCollectionAsync(PagingParams pagingParams)
        {
            return answerChoiceRepository.GetCollectionAsync(pagingParams);
        }

        public Task<List<IAnswerChoice>> GetChoicesByQuestionIdAsync(string questionId)
        {
            return answerChoiceRepository.GetChoicesByQuestionIdAsync(questionId);
        }

        public Task<int> InsertAsync(IAnswerChoice answerChoice)
        {
            return answerChoiceRepository.InsertAsync(answerChoice);
        }

        public Task<int> UpdateAsync(IAnswerChoice answerChoice)
        {
            return answerChoiceRepository.UpdateAsync(answerChoice);
        }

        public Task<int> DeleteAsync(string answerChoiceId)
        {
            return answerChoiceRepository.DeleteAsync(answerChoiceId);
        }

        public Task<int> InsertPictureAsync(IAnswerChoicePicture answerChoicePicture)
        {
            return answerChoiceRepository.InsertPictureAsync(answerChoicePicture);
        }

        public Task<int> UpdatePictureAsync(IAnswerChoicePicture answerChoicePicture)
        {
            return answerChoiceRepository.UpdatePictureAsync(answerChoicePicture);
        }

        public Task<int> DeletePictureAsync(string answerChoicePictureId)
        {
            return answerChoiceRepository.DeleteAsync(answerChoicePictureId);
        }
    }
}
