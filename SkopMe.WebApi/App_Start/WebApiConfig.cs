using SkopMe.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SkopMe.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSystemDiagnosticsTracing();

            //only enable the filter in production
#if !DEBUG
            //Custom section added to check if the request is https
            config.Filters.Add(new RequireHttpsAttributeFilter());
       
#endif

        }
    }
}
