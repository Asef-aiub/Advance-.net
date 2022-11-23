using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BloodDonateAPI.Controllers
{
    public class GroupController : ApiController
    {
        // GET: Group
        [Route("api/groups")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = GroupService.GetGroups();
            return Request.CreateResponse(HttpStatusCode.OK, data);
                }

    }
}
