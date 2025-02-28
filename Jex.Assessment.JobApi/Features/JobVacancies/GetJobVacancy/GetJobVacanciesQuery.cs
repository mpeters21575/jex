namespace Jex.Assessment.JobApi.Features.JobVacancies.GetJobVacancy;

public record GetJobVacanciesQuery(bool? IsActive = null, Guid? CompanyId = null) : ICommand<List<JobVacancy>>;
