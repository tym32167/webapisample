using System.Collections.Generic;
using System.Web.Http;
using Sample.Core.Logging;

namespace Sample.Controllers
{
    public class DefaultController : ApiController
    {
        private readonly ILog _log;

        public DefaultController(ILog log)
        {
            _log = log;
        }

        // GET: api/Default
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default/5
        public string Get(int id)
        {
            _log.DebugFormat("{0} - {1}", "sample message from NLOG by Castle", id);
            return "value";
        }

        // POST: api/Default
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
