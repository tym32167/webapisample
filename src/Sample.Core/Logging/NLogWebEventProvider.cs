using System.Web.Management;

namespace Sample.Core.Logging
{
    public class NLogWebEventProvider : WebEventProvider
    {
        public NLogWebEventProvider()
        {
        }

        public override void ProcessEvent(WebBaseEvent raisedEvent)
        {
            if (raisedEvent is WebRequestErrorEvent || raisedEvent.EventCode == 103005)
                Log.Instance.Error(raisedEvent.ToString(true, true));
            else
                Log.Instance.Info(raisedEvent.ToString(true, true));
        }

        public override void Shutdown()
        {
        }

        public override void Flush()
        {
        }
    }
}