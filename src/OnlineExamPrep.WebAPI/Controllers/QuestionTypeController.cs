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
    [Authorize]
    [RoutePrefix("api/QuestionType")]
    public class QuestionTypeController : ApiController
    {
        protected IQuestionTypeService questionTypeService { get; private set; }

        public QuestionTypeController(IQuestionTypeService questionTypeService)
        {
            this.questionTypeService = questionTypeService;
        }

        [HttpGet]
        [Route("{QuestionTypeId}")]
        public async Task<HttpResponseMessage> GetSingleAsync(string questionTypeId)
        {
            if (!String.IsNullOrEmpty(questionTypeId))
            {
                var questionType = await questionTypeService.GetSingleAsync(questionTypeId);
                return questionType == null ? Request.CreateResponse(HttpStatusCode.NotFound) : Request.CreateResponse(HttpStatusCode.OK, questionType);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("GetCollection")]
        public async Task<HttpResponseMessage> GetCollectionAsync(PagingParams pagingParams)
        {
            var questionTypeList = await questionTypeService.GetCollectionAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, questionTypeList);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> InsertAsync(QuestionType questionType)
        {
            if (questionType != null)
            {
                return Request.CreateResponse(await questionTypeService.InsertAsync(questionType) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("{QuestionTypeId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> UpdateAsync(QuestionType questionType)
        {
            if (questionType != null)
            {
                return Request.CreateResponse(await questionTypeService.UpdateAsync(questionType) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("{QuestionTypeId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> DeleteAsync(string questionTypeId)
        {
            if (!String.IsNullOrEmpty(questionTypeId))
            {
                return Request.CreateResponse(await questionTypeService.DeleteAsync(questionTypeId) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
