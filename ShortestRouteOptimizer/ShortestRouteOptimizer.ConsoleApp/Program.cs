using Microsoft.Extensions.DependencyInjection;
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
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IShortestPathFinder, ShortestPathFinder>()
                .BuildServiceProvider();

            var shortestPathFinder = serviceProvider.GetService<IShortestPathFinder>();

            var graphNodes = CreateDummyGraph();

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

        private static List<Node> CreateDummyGraph()
        {
            var nodeA = new Node("A");
            var nodeB = new Node("B");
            var nodeC = new Node("C");
            var nodeD = new Node("D");
            var nodeE = new Node("E");
            var nodeF = new Node("F");
            var nodeG = new Node("G");
            var nodeH = new Node("H");
            var nodeI = new Node("I");
            nodeA.AddAdjacencyNode(nodeB, 4);
            nodeA.AddAdjacencyNode(nodeH, 8);

            nodeB.AddAdjacencyNode(nodeA, 4);
            nodeB.AddAdjacencyNode(nodeC, 8);
            nodeB.AddAdjacencyNode(nodeH, 11);

            nodeC.AddAdjacencyNode(nodeB, 8);
            nodeC.AddAdjacencyNode(nodeD, 7);
            nodeC.AddAdjacencyNode(nodeF, 4);
            nodeC.AddAdjacencyNode(nodeI, 2);

            nodeD.AddAdjacencyNode(nodeC, 7);
            nodeD.AddAdjacencyNode(nodeE, 9);
            nodeD.AddAdjacencyNode(nodeF, 14);

            nodeE.AddAdjacencyNode(nodeD, 9);
            nodeE.AddAdjacencyNode(nodeF, 10);

            nodeF.AddAdjacencyNode(nodeC, 4);
            nodeF.AddAdjacencyNode(nodeD, 14);
            nodeF.AddAdjacencyNode(nodeE, 10);
            nodeF.AddAdjacencyNode(nodeG, 2);

            nodeG.AddAdjacencyNode(nodeF, 2);
            nodeG.AddAdjacencyNode(nodeH, 1);
            nodeG.AddAdjacencyNode(nodeI, 6);

            nodeH.AddAdjacencyNode(nodeA, 8);
            nodeH.AddAdjacencyNode(nodeB, 11);
            nodeH.AddAdjacencyNode(nodeG, 1);
            nodeH.AddAdjacencyNode(nodeI, 7);

            nodeI.AddAdjacencyNode(nodeC, 2);
            nodeI.AddAdjacencyNode(nodeG, 6);
            nodeI.AddAdjacencyNode(nodeH, 7);

            var graphNodes = new List<Node>
            {
                nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI
            };

            return graphNodes;
        }
    }
}
