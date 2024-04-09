using System.ComponentModel.DataAnnotations;

namespace ShortestRouteOptimizer.Web.Requests
{
    public class FindShortestPathRequest
    {
        [Required]
        public string FromNodeName { get; set; }
        [Required]
        public string ToNodeName { get; set; }
    }
}