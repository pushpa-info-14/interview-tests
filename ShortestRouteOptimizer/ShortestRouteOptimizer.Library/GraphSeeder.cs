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
            nodeA.AddAdjacencyNode(nodeC, 6);

            nodeB.AddAdjacencyNode(nodeA, 4);
            nodeB.AddAdjacencyNode(nodeF, 2);

            nodeC.AddAdjacencyNode(nodeA, 6);
            nodeC.AddAdjacencyNode(nodeD, 8);

            nodeD.AddAdjacencyNode(nodeC, 8);
            nodeD.AddAdjacencyNode(nodeE, 4);
            nodeD.AddAdjacencyNode(nodeG, 1);

            nodeE.AddAdjacencyNode(nodeB, 2);
            nodeE.AddAdjacencyNode(nodeD, 4);
            nodeE.AddAdjacencyNode(nodeF, 3);
            nodeE.AddAdjacencyNode(nodeI, 8);

            nodeF.AddAdjacencyNode(nodeB, 2);
            nodeF.AddAdjacencyNode(nodeE, 3);
            nodeF.AddAdjacencyNode(nodeG, 4);
            nodeF.AddAdjacencyNode(nodeH, 6);

            nodeG.AddAdjacencyNode(nodeD, 1);
            nodeG.AddAdjacencyNode(nodeF, 4);
            nodeG.AddAdjacencyNode(nodeH, 5);
            nodeG.AddAdjacencyNode(nodeI, 5);

            nodeH.AddAdjacencyNode(nodeF, 6);
            nodeH.AddAdjacencyNode(nodeG, 5);

            nodeI.AddAdjacencyNode(nodeE, 8);
            nodeI.AddAdjacencyNode(nodeG, 5);

            var graphNodes = new List<Node>
            {
                nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI
            };

            return graphNodes;
        }
    }
}
