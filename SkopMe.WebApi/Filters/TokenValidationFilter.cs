using SkopMe.Core.Security;
using SkopMe.WebApi.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;
using SkopMe.Core.Helper;
using System.Security.Principal;
using System.Threading;
using System.Net;

namespace SkopMe.WebApi.Filters
{
    public class TokenValidationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string encryptedToken;                   
            
            try
            {
                encryptedToken = actionContext.Request.Headers.GetValues("Authorization-Token").First();
            }
            catch (Exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("Missing Authorization-Token")
                };
                return;
            }

            try
            {
                //decrypt the token
                string decryptedToken = CryptographyHelper.Decrypt(encryptedToken);

                //Get the token object from the header
                Token token = Utility.ProcessHeader(decryptedToken);

                //Validate if the header token is good
                if (!Utility.ValidateHeader(token))
                {
                    throw new InvalidOperationException("Invalid header");
                }
                else
                {
                    //authenticate the user
                    var currentPrincipal = new GenericPrincipal(new GenericIdentity(token.UserId), null);
                    //set the priciapl
                    Thread.CurrentPrincipal = currentPrincipal;
                }

                base.OnActionExecuting(actionContext);
            }
            catch (InvalidOperationException exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Invalid Header")
                };
            }
            catch (Exception exception)
            {
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
                {
                    Content = new StringContent("Unauthorized User")
                };
                return;
            }
        }

    
    }
}
