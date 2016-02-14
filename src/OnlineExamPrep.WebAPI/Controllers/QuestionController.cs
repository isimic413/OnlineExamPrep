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

        [HttpPost]
        [Route("GetPage")]
        public async Task<HttpResponseMessage> GetPageAsync(PagingParams pagingParams)
        {
            var questionList = await questionService.GetPageAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, questionList);
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> CreateQuestionAsync(QuestionParams questionParams)
        {
            var result = await questionService.InsertAsync(questionParams.Question, questionParams.AnswerChoices, questionParams.ExamId);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }

    public class QuestionParams
    {
        public Question Question { get; set; }
        public AnswerChoice[] AnswerChoices { get; set; }
        public string ExamId { get; set; }
    }
}
