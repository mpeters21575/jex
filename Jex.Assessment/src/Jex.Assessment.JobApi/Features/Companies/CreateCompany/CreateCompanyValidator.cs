namespace Jex.Assessment.JobApi.Features.Companies.CreateCompany;

public sealed class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
{

    public CreateCompanyValidator(ICompanyRepository companyRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Company name is required.")
            .MustAsync(async (name, cancellationToken) => ! await companyRepository.ExistsAsync(name, cancellationToken))
            .WithMessage("A company with this name already exists.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Company address is required.");
    }
}
