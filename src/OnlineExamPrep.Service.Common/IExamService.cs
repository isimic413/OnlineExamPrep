using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamPrep.Service.Common
{
    public interface IExamService
    {
        Task<List<dynamic>> GetPageWithQuestionsAndTestingAreaAsync(PagingParams pagingParams);
        Task<IExamParams> GetExamForUpdateAsync(string examId);
        Task<int> InsertAsync(IExam exam);
        Task<int> UpdateAsync(IExam exam);
        Task<int> DeleteAsync(string examId);
    }
}
