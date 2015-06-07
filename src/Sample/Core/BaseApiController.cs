using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sample.Core.Contracts;
using Sample.Core.Logging;
using Sample.Core.Validation;

namespace Sample.Core
{
    public class BaseApiController : ApiController
    {
        protected readonly ILog Log;

        public BaseApiController(ILog log)
        {
            Log = log;
        }

        protected HttpResponseMessage MakeInvalidModelResponse(ModelValidationResult validationResult)
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, validationResult.Summary);
        }
    }
}