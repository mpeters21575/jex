namespace Jex.Assessment.JobApi.Features.Companies.DeleteCompany;

public class DeleteCompanyValidator : AbstractValidator<DeleteCompanyCommand>
{
    public DeleteCompanyValidator(IJobVacancyRepository repository)
    {
        RuleFor(x => x.CompanyId)
            .NotEmpty().WithMessage("Company ID is required.")
            .MustAsync(repository.HasNoVacanciesAsync)
            .WithMessage("The company has active job vacancies and cannot be deleted.");
    }
}