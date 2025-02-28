namespace Jex.Assessment.JobApi.Features.JobVacancies.DeleteJobVacancy;

public class DeleteJobVacancyHandler(IJobVacancyRepository repository, IValidator<DeleteJobVacancyCommand> validator) : IRequestHandler<DeleteJobVacancyCommand, bool>
{
    public async Task<bool> Handle(DeleteJobVacancyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var result = await repository.DeleteAsync(request.Id);
        return result;
    }
}