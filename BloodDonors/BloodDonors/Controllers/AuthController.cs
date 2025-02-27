﻿using BLL.DTO;
using BLL.Service;
using BloodDonors.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace BloodDonors.Controllers
{
    public class AuthController : ApiController
    {
       
        [Route("api/Login")]
        [HttpPost]
        public HttpResponseMessage Login(LoginDTO login)
        {
            if (login == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username password not supplied");
            }
            if (ModelState.IsValid)
            {
                var token = AuthService.Authenticate(login.UserName,login.Password);
                if(token != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,token);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Username password invalid");

            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

    }
}
