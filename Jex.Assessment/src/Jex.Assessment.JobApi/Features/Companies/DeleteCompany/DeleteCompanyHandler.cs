namespace Jex.Assessment.JobApi.Features.Companies.DeleteCompany;

public class DeleteCompanyHandler(ICompanyRepository repository, IValidator<DeleteCompanyCommand> validator) : IRequestHandler<DeleteCompanyCommand, bool>
{
    public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var result = await repository.DeleteAsync(request.CompanyId);
        return result;
    }
}
