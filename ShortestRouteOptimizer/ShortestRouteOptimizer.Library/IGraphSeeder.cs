using System.Collections.Generic;

namespace ShortestRouteOptimizer.Library
{
    public interface IGraphSeeder
    {
        List<Node> SeedGraph();
    }
}
