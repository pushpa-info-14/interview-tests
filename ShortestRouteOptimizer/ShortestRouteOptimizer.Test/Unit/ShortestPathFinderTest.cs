using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortestRouteOptimizer.Library;
using System;
using System.Collections.Generic;

namespace ShortestRouteOptimizer.Test.Unit
{
    [TestClass]
    public class ShortestPathFinderTest
    {
        [TestMethod]
        public void Test1()
        {
            //var graph = new int[,] {
            //    { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
            //    { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
            //    { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
            //    { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
            //    { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
            //    { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
            //    { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
            //    { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
            //    { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
            //};

            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            var nodeD = new Node { Name = "D" };
            var nodeE = new Node { Name = "E" };
            var nodeF = new Node { Name = "F" };
            var nodeG = new Node { Name = "G" };
            var nodeH = new Node { Name = "H" };
            var nodeI = new Node { Name = "I" };
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

            var shortestPathFinder = new ShortestPathFinder();

            var fromNodeName = "A";
            var toNodeName = "B";
            var result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(4, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "C";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(12, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            Assert.AreEqual("C", result.NodeNames[2]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "D";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(19, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            Assert.AreEqual("C", result.NodeNames[2]);
            Assert.AreEqual("D", result.NodeNames[3]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "E";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(21, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("H", result.NodeNames[1]);
            Assert.AreEqual("G", result.NodeNames[2]);
            Assert.AreEqual("F", result.NodeNames[3]);
            Assert.AreEqual("E", result.NodeNames[4]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "F";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(11, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("H", result.NodeNames[1]);
            Assert.AreEqual("G", result.NodeNames[2]);
            Assert.AreEqual("F", result.NodeNames[3]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "G";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(9, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("H", result.NodeNames[1]);
            Assert.AreEqual("G", result.NodeNames[2]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "H";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(8, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("H", result.NodeNames[1]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "I";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(14, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            Assert.AreEqual("C", result.NodeNames[2]);
            Assert.AreEqual("I", result.NodeNames[3]);
            DisplayResult(fromNodeName, toNodeName, result);
        }

        [TestMethod]
        public void Test2()
        {
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            nodeA.AddAdjacencyNode(nodeB, 4);
            nodeB.AddAdjacencyNode(nodeA, 4);
            nodeB.AddAdjacencyNode(nodeC, 8);
            nodeC.AddAdjacencyNode(nodeB, 8);

            var graphNodes = new List<Node>
            {
                nodeC,
                nodeB,
                nodeA
            };

            var shortestPathFinder = new ShortestPathFinder();

            var fromNodeName = "A";
            var toNodeName = "B";
            var result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(4, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "A";
            toNodeName = "C";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(12, result.Distance);
            Assert.AreEqual("A", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            Assert.AreEqual("C", result.NodeNames[2]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "C";
            toNodeName = "A";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(12, result.Distance);
            Assert.AreEqual("C", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            Assert.AreEqual("A", result.NodeNames[2]);
            DisplayResult(fromNodeName, toNodeName, result);

            fromNodeName = "C";
            toNodeName = "B";
            result = shortestPathFinder.ShortestPath(fromNodeName, toNodeName, graphNodes);
            Assert.AreEqual(8, result.Distance);
            Assert.AreEqual("C", result.NodeNames[0]);
            Assert.AreEqual("B", result.NodeNames[1]);
            DisplayResult(fromNodeName, toNodeName, result);
        }

        private void DisplayResult(string fromNodeName, string toNodeName, ShortestPathData result)
        {
            Console.WriteLine($"{fromNodeName} to {toNodeName}: {result.Distance} => " + string.Join(",", result.NodeNames));
        }
    }
}
