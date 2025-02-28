namespace Jex.Assessment.JobApi.Features.Companies.GetCompanies;

public record GetCompaniesQuery() : ICommand<IEnumerable<Company>>;