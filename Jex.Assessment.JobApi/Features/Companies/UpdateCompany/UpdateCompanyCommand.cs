namespace Jex.Assessment.JobApi.Features.Companies.UpdateCompany;

public record UpdateCompanyCommand(Guid Id, string Name, string Address) : ICommand<Company>;