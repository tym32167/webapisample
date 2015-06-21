using System.Web.Http.Filters;

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