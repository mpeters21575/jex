namespace Jex.Assessment.JobApi.Features.JobVacancies.GetJobVacancy;

public static class GetJobVacanciesEndpoint
{
    public static IEndpointRouteBuilder MapGetJobVacanciesEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("jobvacancies/{companyId:guid}", async (Guid companyId, ISender sender) =>
        {
            var vacancies = await sender.Send(new GetJobVacanciesQuery(true, companyId));
            return Results.Ok(vacancies);
        });

        return app;
    }
}