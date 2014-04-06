using SkopMe.WebApi.Filters;
using System.Web;
using System.Web.Mvc;

namespace SkopMe.WebApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
                        
        }
    }
}