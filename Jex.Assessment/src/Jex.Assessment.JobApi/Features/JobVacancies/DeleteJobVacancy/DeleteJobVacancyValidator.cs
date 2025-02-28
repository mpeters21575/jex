namespace Jex.Assessment.JobApi.Features.JobVacancies.DeleteJobVacancy;

public class DeleteJobVacancyValidator : AbstractValidator<DeleteJobVacancyCommand>
{
    public DeleteJobVacancyValidator(IJobVacancyRepository repository)
    {
        RuleFor(x => x.Id)
            .MustAsync((guid, token) => repository.ExistsAsync(guid))
            .WithMessage("Job vacancy not found.");
    }
}