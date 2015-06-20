using System;
using System.Web.Management;

namespace Sample.Core.Logging
{
    public class CustomWebRequestErrorEvent : WebRequestErrorEvent
    {
        protected internal CustomWebRequestErrorEvent(string message, object eventSource, int eventCode, Exception exception)
            : base(message, eventSource, eventCode, exception)
        {
        }

        protected internal CustomWebRequestErrorEvent(string message, object eventSource, int eventCode, int eventDetailCode, Exception exception)
            : base(message, eventSource, eventCode, eventDetailCode, exception)
        {
        }
    }
}