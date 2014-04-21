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
            return null;
        }

        // GET api/account/5
        public string Get(int id)
        {
            return "";
        }

        // POST api/account
        [AllowAnonymous]
        public HttpResponseMessage Login([FromBody] LoginModel model)
        {
            //response object
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                try
                {

                    bool isSuccess = Membership.ValidateUser(model.UserName, model.Password);
                   
                    if (isSuccess)
                    {
                        //initialize the response
                        response = Request.CreateResponse(HttpStatusCode.Accepted, "Successful Login");
                        //add the token
                        response.Headers.Add("Authorization-Token", CryptographyHelper.Encrypt(string.Format("{0}*{1}*{2}", model.UserName, "10-20", DateTime.Now.AddDays(30).ToString())));
                    }
                    else
                        response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Invalid User Name or Password. Please check the user name and password and try again");

                }
                catch (MembershipPasswordException exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Password Exception." + exception.Message);
                }
                catch (Exception exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message);
                }
            }
            else
            {
                //Write all the errors in the response
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, allErrors);
            }

            return response;
        }


        // POST api/account
        [AllowAnonymous]
        public HttpResponseMessage Post([FromBody] RegisterModel model)
        {
            //response object
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                try
                {
                    // Attempt to register the user
                    //MembershipCreateStatus createStatus;
                    //Membership.CreateUser(model.UserName, model.Password, model.Email, "question", "answer", true, null, out createStatus);
                    //TODO to change to IOC
                    RegisterAccountService service = new RegisterAccountService(new RegisterAccountRepository());
                    //Check if we can register the user
                    bool isSuccess = service.RegisterUser(model);

                    if (isSuccess)
                    {
                        //initialize the response
                        response = Request.CreateResponse(HttpStatusCode.Created, "User created");
                        //add the token
                        response.Headers.Add("Authorization-Token", CryptographyHelper.Encrypt(string.Format("{0}*{1}*{2}", model.UserName, "10-20", DateTime.Now.AddDays(30).ToString())));
                    }
                    else
                        response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to create user");

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
            else
            {
                //Write all the errors in the response
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, allErrors);
            }

            return response; 
        }

        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Register([FromBody] RegisterModel model)
        {
            //response object
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                try
                {
                    // Attempt to register the user
                    //MembershipCreateStatus createStatus;
                    //Membership.CreateUser(model.UserName, model.Password, model.Email, "question", "answer", true, null, out createStatus);
                    //TODO to change to IOC
                    RegisterAccountService service = new RegisterAccountService(new RegisterAccountRepository());
                    //Check if we can register the user
                    bool isSuccess = service.RegisterUser(model);

                    if (isSuccess)
                    {
                        //initialize the response
                        response = Request.CreateResponse(HttpStatusCode.Created, "User created");
                        //add the token
                        response.Headers.Add("Authorization-Token", CryptographyHelper.Encrypt(string.Format("{0}*{1}*{2}", model.UserName, "10-20", DateTime.Now.AddDays(30).ToString())));
                    }
                    else
                        response = Request.CreateResponse(HttpStatusCode.InternalServerError, "Unable to create user");

                }
                catch (MembershipCreateUserException exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "User name already exists. Choose another one." + exception.Message);
                }
                catch (Exception exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, exception.Message + exception.StackTrace);
                }
            }
            else
            {
                //Write all the errors in the response
                var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, allErrors);
            }

            return response;
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
