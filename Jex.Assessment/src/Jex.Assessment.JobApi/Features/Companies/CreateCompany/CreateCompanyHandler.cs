namespace Jex.Assessment.JobApi.Features.Companies.CreateCompany;

public class CreateCompanyHandler(ICompanyRepository repository, IValidator<CreateCompanyCommand> validator) : IRequestHandler<CreateCompanyCommand, Company>
{
    public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var company = await repository.AddAsync(new Company(request.Name, request.Address));
        return company;
    }
}