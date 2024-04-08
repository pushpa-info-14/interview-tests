namespace ShortestRouteOptimizer.Library
{
    public class AdjacencyNode
    {
        public Node Node { get; }
        public int Distance { get; }

        public AdjacencyNode(Node node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
