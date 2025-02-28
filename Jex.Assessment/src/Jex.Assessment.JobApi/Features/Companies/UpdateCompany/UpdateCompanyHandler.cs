namespace Jex.Assessment.JobApi.Features.Companies.UpdateCompany;

public class UpdateCompanyHandler(ICompanyRepository repository, IValidator<UpdateCompanyCommand> validator) : IRequestHandler<UpdateCompanyCommand, Company?>
{
    public async Task<Company?> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var company = await repository.UpdateAsync(request.Id, request.Name, request.Address);
        return company;
    }
}