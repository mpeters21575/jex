namespace Jex.Assessment.JobApi.Infrastructure.Exceptions;

public class ValidationException(IReadOnlyCollection<ValidationError> errors) : Exception("Validation failed")
{
    public IReadOnlyCollection<ValidationError> Errors { get; } = errors;
}