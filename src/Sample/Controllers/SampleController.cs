using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sample.Core;
using Sample.Core.Contracts;
using Sample.Core.Validation;
using Sample.Models;

namespace Sample.Controllers
{
    public class SampleController : BaseApiController
    {
        private readonly IRepository<SampleModel, int> _repository;
        private readonly IValidationService _validationService;

        public SampleController(ILog log, IRepository<SampleModel, int> repository, IValidationService validationService ) : base(log)
        {
            _repository = repository;
            _validationService = validationService;
        }

        // GET: api/Default
        public HttpResponseMessage Get()
        {
            return Act(() => {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.All());
            });
        }

        // GET: api/Default/5
        public HttpResponseMessage Get(int id)
        {
            return Act(() =>
            {
                var item = _repository.Get(id);

                if (item != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, item);
                }
                return Request.CreateResponse(HttpStatusCode.NotFound);
            });
        }

        // POST: api/Default
        public HttpResponseMessage Post([FromBody]SampleModel value)
        {
            return Act(() =>
            {
                var valueValidationResult = _validationService.Validate(value);
                if (!valueValidationResult.IsValid) return MakeInvalidModelResponse(valueValidationResult);

                if (_repository.Count(x => x.Id == value.Id) == 0)
                {
                    var validationResult = _validationService.Validate(value);
                    if (!validationResult.IsValid) return MakeInvalidModelResponse(validationResult);
                    var entry = _repository.Add(value);
                    return Request.CreateResponse(HttpStatusCode.Created, entry);
                }
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error.");
            });
        }

        // PUT: api/Default/5
        public HttpResponseMessage Put(int id, [FromBody]SampleModel value)
        {
            return Act(() =>
            {

                value.Id = id;
                var validationResult = _validationService.Validate(value);
                if (!validationResult.IsValid) return MakeInvalidModelResponse(validationResult);

                if (value != null
                    && _repository.Get(value.Id) != null)
                {
                    _repository.Update(value);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            });
        }

        // DELETE: api/Default/5
        public HttpResponseMessage Delete(int id)
        {
            return Act(() =>
            {
                var item = _repository.Get(id);
                if (item != null)
                {
                    _repository.Delete(item);
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            });
        }
    }
}
