namespace Jex.Assessment.JobApi.Features.JobVacancies.GetJobVacancy;

public class GetJobVacanciesHandler(ApplicationDbContext context)
    : IRequestHandler<GetJobVacanciesQuery, List<JobVacancy>>
{
    public Task<List<JobVacancy>> Handle(GetJobVacanciesQuery request, CancellationToken cancellationToken) =>
        context.JobVacancies
            .Where(jv => 
                (!request.IsActive.HasValue || jv.IsActive == request.IsActive.Value) &&
                (!request.CompanyId.HasValue || jv.CompanyId == request.CompanyId.Value))
            .Include(jv => jv.Company)
            .ToListAsync(cancellationToken);
}