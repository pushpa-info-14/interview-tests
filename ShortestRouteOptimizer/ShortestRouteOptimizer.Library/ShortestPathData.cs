namespace ShortestRouteOptimizer.Library
{
    public class ShortestPathData
    {
        public string[] NodeNames { get; set; }
        public int Distance { get; set; }

        public ShortestPathData(string[] nodeNames, int distance)
        {
            NodeNames = nodeNames;
            Distance = distance;
        }
    }
}
