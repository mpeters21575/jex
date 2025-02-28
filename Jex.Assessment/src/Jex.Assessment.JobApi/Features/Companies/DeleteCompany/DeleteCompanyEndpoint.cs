namespace Jex.Assessment.JobApi.Features.Companies.DeleteCompany;

public static class DeleteCompanyEndpoint
{
    public static IEndpointRouteBuilder MapDeleteCompanyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("companies/{companyId:guid}", async (Guid companyId, ISender sender) =>
        {
            await sender.Send(new DeleteCompanyCommand(companyId));
            return Results.NoContent();
        });

        return app;
    }
}