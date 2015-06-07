namespace Sample.Core.Validation
{
    public interface IValidationService
    {
        ModelValidationResult Validate<T>(T model) where T : class;
    }
}