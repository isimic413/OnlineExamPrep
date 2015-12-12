using OnlineExamPrep.Common;
using OnlineExamPrep.Models.Common;
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
    }
}
