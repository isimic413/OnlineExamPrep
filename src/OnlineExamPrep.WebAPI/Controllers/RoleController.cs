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
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        protected IRoleService roleService { get; private set; }

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpGet]
        [Route("{RoleId}")]
        public async Task<HttpResponseMessage> GetSingleAsync(string roleId)
        {
            if (!String.IsNullOrEmpty(roleId))
            {
                var role = await roleService.GetSingleAsync(roleId);
                return role != null ? Request.CreateResponse(HttpStatusCode.OK, role) : Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("GetCollection")]
        public async Task<HttpResponseMessage> GetCollectionAsync(PagingParams pagingParams)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await roleService.GetCollectionAsync(pagingParams));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> InsertAsync(Role role)
        {
            if (role != null)
            {
                return Request.CreateResponse(await roleService.InsertAsync(role) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPut]
        [Route("{RoleId}")]
        public async Task<HttpResponseMessage> UpdateAsync(Role role)
        {
            if (role != null)
            {
                return Request.CreateResponse(await roleService.UpdateAsync(role) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpDelete]
        [Route("{RoleId}")]
        public async Task<HttpResponseMessage> DeleteAsync(string roleId)
        {
            if (!String.IsNullOrEmpty(roleId))
            {
                return Request.CreateResponse(await roleService.DeleteAsync(roleId) > 0 ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
