using System.Web.Http.ExceptionHandling;
using Sample.Core.Contracts;
using Sample.Core.Extensions;

namespace Sample.Core.Logging
{
    public class NLogExceptionLogger : ExceptionLogger
    {
        private readonly ILog _log;

        public NLogExceptionLogger(ILog log)
        {
            _log = log;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            base.Log(context);
            _log.Error(context.ConvertToString());
        }
    }
}