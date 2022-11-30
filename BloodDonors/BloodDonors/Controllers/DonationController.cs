using BLL.DTO;
using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonors.Controllers
{
    [EnableCors("*", "*", "*")]
    public class DonationController : ApiController
    {
        [Route("api/groups")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data=GroupService.Get();
            return Request.CreateResponse(HttpStatusCode.OK,data);
        }
        [Route("api/groups/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = GroupService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/groups/add")]
        [HttpPost]
        public HttpResponseMessage Post(GroupDTO group)
        {
            var data = GroupService.ADD(group);
            if(data==true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, new {Msg="Inserted",data=group});
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
