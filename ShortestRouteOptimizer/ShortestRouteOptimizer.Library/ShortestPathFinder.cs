using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestRouteOptimizer.Library
{
    public class ShortestPathFinder : IShortestPathFinder
    {
        public ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes)
        {
            var fromNode = graphNodes.Find(x => x.Name == fromNodeName);
            var toNode = graphNodes.Find(x => x.Name == toNodeName);
            if (fromNode == null || toNode == null)
            {
                throw new Exception("Invalid source or destination");
            }

            var distances = new Dictionary<Node, int>();
            var previous = new Dictionary<Node, Node>();
            var visited = new HashSet<Node>();

            foreach (var node in graphNodes)
            {
                distances.Add(node, int.MaxValue);
                previous.Add(node, null);
            }

            distances[fromNode] = 0;

            foreach (var t in graphNodes)
            {
                var u = FindMinDistance(distances, visited);
                visited.Add(u);

                var node = graphNodes.Find(x => x == u);
                if (node == null)
                {
                    continue;
                }

                foreach (var adjacencyNode in node.AdjacencyNodeList)
                {
                    if (!visited.Contains(adjacencyNode.Node) &&
                        distances[u] != int.MaxValue &&
                        distances[u] + adjacencyNode.Distance < distances[adjacencyNode.Node])
                    {
                        distances[adjacencyNode.Node] = distances[u] + adjacencyNode.Distance;
                        previous[adjacencyNode.Node] = node;
                    }
                }
            }

            return new ShortestPathData(GetPath(fromNode, toNode, previous), distances[toNode]);
        }

        private List<string> GetPath(Node from, Node to, IReadOnlyDictionary<Node, Node> previous)
        {
            var path = new Stack<Node>();
            var current = to;
            while (current != from)
            {
                path.Push(current);
                current = previous[current];
            }

            path.Push(from);

            return path.Select(x => x.Name).ToList();
        }

        private Node FindMinDistance(Dictionary<Node, int> distances, ICollection<Node> visited)
        {
            Node minNode = null;
            var minValue = int.MaxValue;

            foreach (var distance in distances)
            {
                if (!visited.Contains(distance.Key) && distance.Value <= minValue)
                {
                    minNode = distance.Key;
                    minValue = distance.Value;
                }
            }

            return minNode;
        }
    }
}
