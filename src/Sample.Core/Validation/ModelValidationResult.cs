using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Core.Validation
{
    public class ModelValidationResult
    {
        public ModelValidationResult(bool isValid, IEnumerable<ValidationResult> validationResults)
        {
            IsValid = isValid;
            ValidationResults = validationResults;

            _summary = new Lazy<string>(() =>
            {
                var sb = new StringBuilder(string.Empty);
                if (ValidationResults != null)
                {
                    foreach (var validationResult in ValidationResults)
                    {
                        sb.AppendLine(validationResult.ErrorMessage);
                    }
                }
                return sb.ToString();
            });
        }

        public bool IsValid { get; private set; }

        public IEnumerable<ValidationResult> ValidationResults { get; private set; }

        private readonly Lazy<string> _summary;

        public string Summary
        {
            get { return _summary.Value; }
        }
    }
}