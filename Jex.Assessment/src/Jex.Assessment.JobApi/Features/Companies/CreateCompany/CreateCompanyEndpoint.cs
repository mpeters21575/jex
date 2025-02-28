namespace Jex.Assessment.JobApi.Features.Companies.CreateCompany;

public static class CreateCompanyEndpoint
{
    public static IEndpointRouteBuilder MapCreateCompanyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("companies", async (CreateCompanyCommand command, ISender sender) =>
        {
            var company = await sender.Send(command);
            return Results.Ok(company);
        });

        return app;
    }
}