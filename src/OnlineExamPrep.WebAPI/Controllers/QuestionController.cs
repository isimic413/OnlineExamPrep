using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
using OnlineExamPrep.Models.Common;
using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OnlineExamPrep.WebAPI.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Question")]
    public class QuestionController : ApiController
    {
        protected IQuestionService questionService { get; private set; }

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpGet]
        [Route("{QuestionId}")]
        public async Task<HttpResponseMessage> GetSingleAsync(string questionId)
        {
            if (!String.IsNullOrEmpty(questionId))
            {
                var questionType = await questionService.GetSingleAsync(questionId);
                return questionType == null ? Request.CreateResponse(HttpStatusCode.NotFound) : Request.CreateResponse(HttpStatusCode.OK, questionType);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("GetCollection")]
        public async Task<HttpResponseMessage> GetCollectionAsync(PagingParams pagingParams)
        {
            var questions = await questionService.GetCollectionAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, questions);
        }

        [HttpPost]
        [Route("InsertWithChoices")]
        public async Task<HttpResponseMessage> InsertWithChoicesAsync(QuestionWithChoicesParams insertParams)
        {
            if (insertParams != null)
            {
                return Request.CreateResponse(await questionService.InsertAsync(insertParams.Question, Mapper.Map<List<IAnswerChoice>>(insertParams.Choices)) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public class QuestionWithChoicesParams
        {
            public Question Question { get; set; }
            public List<AnswerChoice> Choices { get; set; }
        }
    }
}
