using System;
using System.Web.Mvc;

namespace ShortestRouteOptimizer.Web.Filters
{
    public class ValidationException : ApplicationException
    {
        public JsonResult ExceptionDetails;
        public ValidationException(JsonResult exceptionDetails)
        {
            this.ExceptionDetails = exceptionDetails;
        }
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception inner) : base(message, inner) { }
        protected ValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public ValidationException() : base()
        {
        }
    }
}