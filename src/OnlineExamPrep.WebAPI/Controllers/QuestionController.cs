﻿using AutoMapper;
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
    [Authorize]
    [RoutePrefix("api/question")]
    public class QuestionController : ApiController
    {
        protected IQuestionService questionService { get; private set; }

        public QuestionController(IQuestionService questionService)
        {
            this.questionService = questionService;
        }

        [HttpPost]
        [Route("page")]
        public async Task<HttpResponseMessage> GetPageAsync(PagingParams pagingParams)
        {
            var questionList = await questionService.GetPageAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, questionList);
        }

        [HttpGet]
        [Route("{questionId}")]
        public async Task<HttpResponseMessage> GetQuestionAsync(string questionId)
        {
            var question = await questionService.GetQuestionForUpdateAsync(questionId);
            if (question != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, question);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> UpdateQuestionWithChoicesAsync(QuestionParams questionParams)
        {
            await questionService.UpdateQuestionAsync(questionParams.Question, questionParams.AnswerChoices);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> CreateQuestionAsync(QuestionParams questionParams)
        {
            var result = await questionService.InsertAsync(questionParams.Question, questionParams.AnswerChoices, questionParams.ExamId);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("{questionId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> DeleteQuestionAsync(string questionId)
        {
            var result = await questionService.DeleteQuestionAsync(questionId);
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }

    public class QuestionParams
    {
        public Question Question { get; set; }
        public AnswerChoice[] AnswerChoices { get; set; }
        public string ExamId { get; set; }
    }
}
