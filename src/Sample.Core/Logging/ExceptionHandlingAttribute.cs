using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using Sample.Core.Contracts;

namespace Sample.Core.Logging
{

    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var log = context.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILog)) as ILog;

            if (log != null) log.Error(context.Exception);
            #if !DEBUG
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            #endif
        }
    }
}
