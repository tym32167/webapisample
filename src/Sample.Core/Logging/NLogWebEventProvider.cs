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
            Log.Instance.Debug(raisedEvent.ToString(true, true));
        }

        public override void Shutdown()
        {

        }

        public override void Flush()
        {

        }
    }
}