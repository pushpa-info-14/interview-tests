using Autofac;
using Autofac.Integration.Mvc;
using ShortestRouteOptimizer.Library;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ShortestRouteOptimizer.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var graphSeeder = new GraphSeeder();
            var graph = graphSeeder.SeedGraph();
            builder.RegisterInstance(graph);
            builder.RegisterInstance(new ShortestPathFinder()).As<IShortestPathFinder>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
