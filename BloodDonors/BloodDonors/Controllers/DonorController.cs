using BLL.DTO;
using BLL.Service;
using BloodDonors.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BloodDonors.Controllers
{
    [EnableCors("*","*","*")]
    [Logeed]
    public class DonorController : ApiController
    {
        [Route("api/Donors")]
        [HttpGet]
        
        public HttpResponseMessage Get()
        {
            var data = DonorService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Donors/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = DonorService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/Donors/add")]
        [HttpPost]
        public HttpResponseMessage Post(DonorDTO donor)
        {
            var data = DonorService.Add(donor);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
