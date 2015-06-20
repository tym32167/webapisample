using System;
using System.Web.Http.Filters;
using System.Web.Management;

namespace Sample.Core.Logging
{

    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            new CustomWebRequestErrorEvent("An unhandled exception has occured.", this, 103005, context.Exception).Raise();
#if !DEBUG
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
#endif
        }
    }
}
