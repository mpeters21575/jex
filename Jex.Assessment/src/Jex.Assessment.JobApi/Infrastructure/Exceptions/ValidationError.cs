namespace Jex.Assessment.JobApi.Infrastructure.Exceptions;

public record ValidationError(string PropertyName, string ErrorMessage);