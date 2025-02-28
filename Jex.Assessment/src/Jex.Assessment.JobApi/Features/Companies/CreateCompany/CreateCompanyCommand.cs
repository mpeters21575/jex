namespace Jex.Assessment.JobApi.Features.Companies.CreateCompany;

public record CreateCompanyCommand(string Name, string Address) : ICommand<Company>;