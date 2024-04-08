using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public class Node
    {
        public string Name { get; set; }
        public List<AdjacencyNode> AdjacencyNodeList { get; set; } = new List<AdjacencyNode>();

        public void AddAdjacencyNode(Node node, int distance)
        {
            AdjacencyNodeList.Add(new AdjacencyNode(node, distance));
        }
    }
}
