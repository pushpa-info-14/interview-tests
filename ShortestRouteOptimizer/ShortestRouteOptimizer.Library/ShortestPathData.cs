using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public class ShortestPathData
    {
        public List<string> NodeNames { get; set; }
        public int Distance { get; set; }

        public ShortestPathData(List<string> nodeNames, int distance)
        {
            NodeNames = nodeNames;
            Distance = distance;
        }
    }
}
