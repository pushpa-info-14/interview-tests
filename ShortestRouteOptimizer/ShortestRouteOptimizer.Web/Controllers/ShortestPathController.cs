using ShortestRouteOptimizer.Library;
using ShortestRouteOptimizer.Web.Attributes;
using ShortestRouteOptimizer.Web.Requests;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ShortestRouteOptimizer.Web.Controllers
{
    public class ShortestPathController : Controller
    {
        private readonly IShortestPathFinder _shortestPathFinder;
        private readonly List<Node> _graphNodes;

        public ShortestPathController(IShortestPathFinder shortestPathFinder, List<Node> graphNodes)
        {
            _shortestPathFinder = shortestPathFinder;
            _graphNodes = graphNodes;
        }

        public ActionResult Index()
        {
            return View(_graphNodes);
        }

        [HttpPost]
        [HandleException]
        public JsonResult Calculate(FindShortestPathRequest request)
        {
            var result = _shortestPathFinder.ShortestPath(request.FromNodeName, request.ToNodeName, _graphNodes);
            return Json(result);
        }
    }
}