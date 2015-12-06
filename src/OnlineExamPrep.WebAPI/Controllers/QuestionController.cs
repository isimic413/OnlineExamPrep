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
    }
}
