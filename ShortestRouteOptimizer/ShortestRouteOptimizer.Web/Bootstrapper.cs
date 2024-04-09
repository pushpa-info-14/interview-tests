using Microsoft.Practices.Unity;
using ShortestRouteOptimizer.Library;
using System.Web.Mvc;
using Unity.Mvc4;

namespace ShortestRouteOptimizer.Web
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //container.RegisterType<IShortestPathFinder, ShortestPathFinder>();

            IShortestPathFinder shortestPathFinder = new ShortestPathFinder();
            IGraphSeeder seeder = new GraphSeeder();
            var nodes = seeder.SeedGraph();
            container.RegisterInstance(shortestPathFinder);
            container.RegisterInstance(nodes);

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {

        }
    }
}