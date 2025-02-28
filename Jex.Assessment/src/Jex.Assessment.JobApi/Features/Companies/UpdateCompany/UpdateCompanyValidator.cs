namespace Jex.Assessment.JobApi.Features.Companies.UpdateCompany;

public class UpdateCompanyValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Company name is required.");
        RuleFor(x => x.Address).NotEmpty().WithMessage("Company address is required.");
    }
}