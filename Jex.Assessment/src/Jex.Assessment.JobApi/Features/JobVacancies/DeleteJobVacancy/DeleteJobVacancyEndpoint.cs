namespace Jex.Assessment.JobApi.Features.JobVacancies.DeleteJobVacancy;

public static class DeleteJobVacancyEndpoint
{
    public static IEndpointRouteBuilder MapDeleteJobVacancyEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("jobvacancies/{jobVacancyId:guid}", async (Guid jobVacancyId, ISender sender) =>
        {
            await sender.Send(new DeleteJobVacancyCommand(jobVacancyId));
            return Results.NoContent();
        });

        return app;
    }
}