﻿using OnlineExamPrep.Common;
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

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> InsertAsync(Exam exam)
        {
            if (exam != null)
            {
                return Request.CreateResponse(await examService.InsertAsync(exam) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
