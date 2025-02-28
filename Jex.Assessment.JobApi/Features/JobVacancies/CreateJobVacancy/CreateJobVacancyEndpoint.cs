namespace Jex.Assessment.JobApi.Features.JobVacancies.CreateJobVacancy;

public static class CreateJobVacancyEndpoint
{
    public static IEndpointRouteBuilder MapCreateJobVacancyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("jobvacancies", async (CreateJobVacancyCommand command, ISender sender) =>
        {
            var vacancy = await sender.Send(command);
            return Results.Ok(vacancy);
        });

        return app;
    }
}