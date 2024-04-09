using Microsoft.Extensions.DependencyInjection;
using ShortestRouteOptimizer.Library;
using System;
using System.Linq;

namespace ShortestRouteOptimizer.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IShortestPathFinder, ShortestPathFinder>()
                .AddSingleton<IGraphSeeder, GraphSeeder>()
                .BuildServiceProvider();

            var shortestPathFinder = serviceProvider.GetService<IShortestPathFinder>();
            var graphSeeder = serviceProvider.GetService<IGraphSeeder>();

            var graphNodes = graphSeeder.SeedGraph();

            while (true)
            {

                Console.WriteLine($"Graph Nodes: {string.Join(",", graphNodes.Select(x => x.Name))}");

                try
                {
                    Console.Write("Enter FromNode: ");
                    var fromNodeName = Console.ReadLine()?.ToUpper();
                    Console.Write("Enter ToNode: ");
                    var toNodeName = Console.ReadLine()?.ToUpper();

                    var result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);

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
    }
}
