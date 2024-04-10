using Autofac;
using ShortestRouteOptimizer.Library;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestRouteOptimizer.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var shortestPathFinder = container.Resolve<IShortestPathFinder>();
            var graph = container.Resolve<List<Node>>();


            while (true)
            {

                Console.WriteLine($"Graph Nodes: {string.Join(",", graph.Select(x => x.Name))}");

                try
                {
                    Console.Write("Enter FromNode: ");
                    var fromNodeName = Console.ReadLine()?.ToUpper();
                    Console.Write("Enter ToNode: ");
                    var toNodeName = Console.ReadLine()?.ToUpper();

                    var result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graph);

                    Console.WriteLine($"{fromNodeName} to {toNodeName}: Distance = {result.Distance}, Path = " +
                                      string.Join(",", result.NodeNames));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Write("Do you want to continue (y/n): ");
                var input = Console.ReadLine();
                if (input?.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            var graphSeeder = new GraphSeeder();
            var graph = graphSeeder.SeedGraph();
            builder.RegisterInstance(graph);
            builder.RegisterInstance(new ShortestPathFinder()).As<IShortestPathFinder>();

            return builder.Build();
        }
    }
}
