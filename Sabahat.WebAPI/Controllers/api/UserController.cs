using Sabahat.Business.Users;
using Sabahat.Data.Users;
using Sabahat.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sabahat.WebAPI.Controllers.api
{
    public class UserController : ApiController
    {
        private IUserBusiness _userBusiness;

        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
            Request = new HttpRequestMessage();
            Configuration = new HttpConfiguration();
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = _userBusiness.GetUsers();

                if (result.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Benutzer nicht gefunden");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public HttpResponseMessage PostUsers([FromBody] UserModel input)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Model Is Not Valid!");

                var users = new List<User>();
                users.Add(new User
                {
                    Name = input.Name,
                    LastName = input.LastName,
                    ZipCode = input.ZipCode,
                    City = input.City,
                    JobLevel = input.JobLevel,
                });

                var result = _userBusiness.PostUsers(users);

                var message = Request.CreateResponse(HttpStatusCode.Created, result);
                return message;
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
