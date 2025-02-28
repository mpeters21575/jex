namespace Jex.Assessment.JobApi.Features.JobVacancies.CreateJobVacancy;

public class CreateJobVacancyValidator : AbstractValidator<CreateJobVacancyCommand>
{
    public CreateJobVacancyValidator(ICompanyRepository repository)
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Job vacancy title is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Job vacancy description is required.");
        RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Company ID is required.");
        RuleFor(x => x.CompanyId)
            .MustAsync(repository.ExistsAsync).WithMessage("Company does not exist.");
    }
}