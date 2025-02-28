namespace Jex.Assessment.JobApi.Features.Companies.DeleteCompany;

public record DeleteCompanyCommand(Guid CompanyId) : ICommand<bool>;