using SkopMe.Web.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SkopMe.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //Dependency injection initialize
            Bootstrapper.Initialise();
            
            //need to review
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }


        /// <summary>
        /// Custom call to get the Claims
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var transformer = new ClaimsTransformer();
            var principal = transformer.Authenticate(string.Empty, ClaimsPrincipal.Current);

            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
        }

    }
}