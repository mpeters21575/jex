namespace Jex.Assessment.JobApi.Features.Companies.GetCompanies;

public static class GetCompaniesEndpoint
{
    public static IEndpointRouteBuilder MapGetCompaniesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("companies", async (ICompanyRepository companyRepository) =>
        {
            var companies = await companyRepository.GetAllAsync();
            return Results.Ok(companies);
        });

        return app;
    }
}