using AutoMapper;
using OnlineExamPrep.Common;
using OnlineExamPrep.Models;
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
    [RoutePrefix("api/testing-area")]
    public class TestingAreaController : ApiController
    {
        protected ITestingAreaService testingAreaService { get; private set; }

        public TestingAreaController(ITestingAreaService testingAreaService)
        {
            this.testingAreaService = testingAreaService;
        }

        [HttpGet]
        [Route("{TestingAreaId}")]
        public async Task<HttpResponseMessage> GetSingleAsync(string testingAreaId)
        {
            if (!String.IsNullOrEmpty(testingAreaId))
            {
                var testingArea = await testingAreaService.GetSingleAsync(testingAreaId);
                return testingArea == null ? Request.CreateResponse(HttpStatusCode.NotFound) : Request.CreateResponse(HttpStatusCode.OK, testingArea);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("page")]
        public async Task<HttpResponseMessage> GetDatasetAsync(PagingParams pagingParams)
        {
            var result = await testingAreaService.GetCollectionAsync(pagingParams);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> InsertAsync(TestingArea testingArea)
        {
            if (testingArea != null)
            {
                return Request.CreateResponse(await testingAreaService.InsertAsync(testingArea) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("{TestingAreaId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> UpdateAsync(TestingArea testingArea)
        {
            if (testingArea != null)
            {
                return Request.CreateResponse(await testingAreaService.UpdateAsync(testingArea) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("{TestingAreaId}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<HttpResponseMessage> DeleteAsync(string testingAreaId)
        {
            if (!String.IsNullOrEmpty(testingAreaId))
            {
                return Request.CreateResponse(await testingAreaService.DeleteAsync(testingAreaId) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
