using OnlineExamPrep.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace OnlineExamPrep.WebAPI.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        protected IUserService userService { get; private set; }

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("ApplicationData")]
        public async Task<HttpResponseMessage> GetApplicationData()
        {
            var data = await userService.GetApplicationData(User.Identity.GetUserId());
            return Request.CreateResponse(HttpStatusCode.OK, (object)data);
        }
    }
}
