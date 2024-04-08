namespace ShortestRouteOptimizer.Library
{
    public class AdjacencyNode
    {
        public Node Node { get; set; }
        public int Distance { get; set; }

        public AdjacencyNode(Node node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
