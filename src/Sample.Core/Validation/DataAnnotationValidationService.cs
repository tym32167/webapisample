using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sample.Core.Contracts;
using Sample.Core.Logging;

namespace Sample.Core.Validation
{
    public class DataAnnotationValidationService : IValidationService
    {
        private readonly ILog _log;

        public DataAnnotationValidationService(ILog log)
        {
            _log = log;
        }

        public ModelValidationResult Validate<T>(T model) where T : class
        {
            try
            {
                var context = new ValidationContext(model);
                var results = new List<ValidationResult>();
                var isvalid = Validator.TryValidateObject(
                    model, context, results,
                    validateAllProperties: true
                    );

                return new ModelValidationResult(isvalid, results);
            }
            catch (Exception e)
            {
                _log.Error(e);
                return new ModelValidationResult(false, new []{new ValidationResult(e.Message) } );
            }
        }
    }
}