using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineExamPrep.Repository.Common
{
    public interface IAnswerChoiceRepository
    {
        IUnitOfWork GetUnitOfWork();
        Task<int> AddForInsertAsync(IUnitOfWork unitOfWork, IAnswerChoice answerChoice);
    }
}
