using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
using OnlineExamPrep.Service.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineExamPrep.WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Exam")]
    public class ExamController : ApiController
    {
        protected IExamService examService { get; private set; }

        public ExamController(IExamService examService)
        {
            this.examService = examService;
        }

        [HttpPost]
        [Route("GetPage")]
        public async Task<HttpResponseMessage> GetPageAsync(PagingParams pagingParams)
        {
            var examList = await examService.GetPageWithQuestionsAndTestingAreaAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, examList);
        }

    }
}
