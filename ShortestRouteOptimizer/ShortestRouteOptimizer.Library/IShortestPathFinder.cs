using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public interface IShortestPathFinder
    {
        ShortestPathData ShortestPath(string fromNodeName, string toNodeName, List<Node> graphNodes);
    }
}
