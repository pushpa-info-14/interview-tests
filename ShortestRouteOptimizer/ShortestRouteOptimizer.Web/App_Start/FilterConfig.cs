using ShortestRouteOptimizer.Web.Attributes;
using System.Web.Mvc;

namespace ShortestRouteOptimizer.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new HandleExceptionAttribute());
        }
    }
}
