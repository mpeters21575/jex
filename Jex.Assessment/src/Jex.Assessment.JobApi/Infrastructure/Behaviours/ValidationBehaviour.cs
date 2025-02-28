using Jex.Assessment.JobApi.Infrastructure.Exceptions;

namespace Jex.Assessment.JobApi.Infrastructure.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommandBase
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);
        var validationFailures = await Task.WhenAll(
            _validators
                .Select(validator => validator.ValidateAsync(context, cancellationToken)));
        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage
            ))
            .ToList();

        if (errors.Any())
        {
            throw new Exceptions.ValidationException(errors);
        }

        var response = await next();

        return response;
    }
}

public interface ICommand : IRequest, ICommandBase
{
    
}

public interface ICommand<TReponse> : IRequest<TReponse>, ICommandBase
{
    
}

public interface ICommandBase
{
    
}