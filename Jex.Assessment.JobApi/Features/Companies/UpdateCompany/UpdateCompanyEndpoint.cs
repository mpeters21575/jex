namespace Jex.Assessment.JobApi.Features.Companies.UpdateCompany;

public static class UpdateCompanyEndpoint
{
    public static IEndpointRouteBuilder MapUpdateCompanyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("companies", async (UpdateCompanyCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.Ok();
        });

        return app;
    }
}