using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace SkopMe.Web.Security
{
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
      
        /// <summary>
        /// Check for a particular resource does he have the claims to access it
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool CheckAccess(AuthorizationContext context)
        {
            var resource = context.Resource.First().Value;
            var claims = context.Principal.Claims.ToList();

            switch (resource)
            {
                case "Profile":
                    {
                        if (PrincipalCanPerformActionOnResource(context))
                            return true;
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(string.Format("{0} is not a valid resource", resource));
                    }
            }

            return false;
        }

        /// <summary>
        /// Check for a particular action he has the claims
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool PrincipalCanPerformActionOnResource(AuthorizationContext context)
        {
            var action = context.Action.First().Value;

            switch (action)
            {
                case "Edit":
                    {
                        if (context.Principal.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                                                       "admin"))
                        {
                            return true;
                        }
                        break;
                    }
                default:
                    {
                        throw new NotSupportedException(string.Format("{0} is not a valid action", action));
                    }
            }

            return false;
        }
    }
}