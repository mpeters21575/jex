namespace Jex.Assessment.JobApi.Features.JobVacancies.UpdateJobVacancy;

public static class UpdateJobVacancyEndpoint
{
    public static IEndpointRouteBuilder MapUpdateJobVacancyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("jobvacancies", async (UpdateJobVacancyCommand command, ISender sender) =>
        {
            await sender.Send(command);
            return Results.Ok();
        });

        return app;
    }
}