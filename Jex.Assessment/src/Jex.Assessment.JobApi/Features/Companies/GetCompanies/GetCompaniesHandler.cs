namespace Jex.Assessment.JobApi.Features.Companies.GetCompanies;

public class GetCompaniesHandler(ICompanyRepository repository)
    : IRequestHandler<GetCompaniesQuery, IEnumerable<Company>>
{
    public async Task<IEnumerable<Company>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        => await repository.GetAllAsync();
}