using SkopMe.Core.Helper;
using SkopMe.Core.Security;
using SkopMe.Repositories;
using SkopMe.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace SkopMe.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        // GET api/account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1xx", "value2xxx" };
        }

        // GET api/account/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/account
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] RegisterModel model)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                RegisterAccountService service = new RegisterAccountService(new RegisterAccountRepository());
                bool isSuccess = service.RegisterUser(model);

                if (isSuccess)
                {
                    //initialize the response
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, "User created");
                    //add the token
                    response.Headers.Add("Authorization-Token", CryptographyHelper.Encrypt(string.Format("{0}*{1}*{2}", model.UserName, "10-20", DateTime.Now.AddDays(30).ToString())));

                    return response;
                }
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to create user");
                //}
                //else
                //{
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid Model");
                //}
            }
            catch (MembershipCreateUserException exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "User name already exists. Choose another one." + exception.Message);
            }
            catch (Exception exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        // PUT api/account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/account/5
        public void Delete(int id)
        {
        }
    }
}
