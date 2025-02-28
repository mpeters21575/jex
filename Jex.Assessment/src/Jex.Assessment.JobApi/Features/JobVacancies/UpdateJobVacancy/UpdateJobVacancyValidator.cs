namespace Jex.Assessment.JobApi.Features.JobVacancies.UpdateJobVacancy;

public class UpdateJobVacancyValidator : AbstractValidator<UpdateJobVacancyCommand>
{
    public UpdateJobVacancyValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Job vacancy title is required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Job vacancy description is required.");
    }
}