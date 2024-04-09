using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public class GraphSeeder : IGraphSeeder
    {
        public List<Node> SeedGraph()
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
