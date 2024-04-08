using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public class Node
    {
        public string Name { get; }
        public List<AdjacencyNode> AdjacencyNodeList { get; } = new List<AdjacencyNode>();

        public Node(string name)
        {
            Name = name;
        }

        public void AddAdjacencyNode(Node node, int distance)
        {
            AdjacencyNodeList.Add(new AdjacencyNode(node, distance));
        }
    }
}
