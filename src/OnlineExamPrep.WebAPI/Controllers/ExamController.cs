using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Models.Common.ParamsModel;
using OnlineExamPrep.Service.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineExamPrep.WebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/exam")]
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

        [HttpPost]
        [Route("page")]
        public async Task<HttpResponseMessage> GetCollectionAsync(PagingParams pagingParams)
        {
            var list = await examService.GetCollectionAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpGet]
        [Route("questions/{examId}")]
        public async Task<HttpResponseMessage> GetFullExamQuestionsAsync(string examId)
        {
            var data = await examService.GetExamDataForSimulationAsync(examId);
            return Request.CreateResponse(HttpStatusCode.OK, (object)data);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> InsertAsync(Exam exam)
        {
            if (exam != null)
            {
                return Request.CreateResponse(await examService.InsertAsync(exam) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpGet]
        [Route("questionPreviews/{examId}")]
        public async Task<HttpResponseMessage> GetExamQuestionPreviewsAsync(string examId)
        {
            var list = await examService.GetExamQuestionsAsync(examId);
            return Request.CreateResponse(HttpStatusCode.OK, (object)list);
        }

        [HttpPut]
        [Route("{examId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> UpdateAsync(Exam exam)
        {
            var result = await examService.UpdateAsync(exam);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("{examId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> DeleteAsync(string examId)
        {
            var result = await examService.DeleteAsync(examId);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpGet]
        [Route("{examId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> GetExamForUpdateAsync(string examId)
        {
            var exam = await examService.GetExamForUpdateAsync(examId);
            return Request.CreateResponse(HttpStatusCode.OK, exam);
        }

        [HttpPut]
        [Route("questionOrder/{examId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> UpdateQuestionOrderAsync(ExamQuestionOrderParams orderParams)
        {
            await examService.UpdateQuestionOrderAsync(orderParams.ExamId, orderParams.ExamQuestions);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }

    public class ExamQuestionOrderParams
    {
        public ExamQuestion[] ExamQuestions { get; set; }
        public string ExamId { get; set; }
    }
}
