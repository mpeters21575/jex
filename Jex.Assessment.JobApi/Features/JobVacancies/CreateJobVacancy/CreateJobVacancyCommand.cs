namespace Jex.Assessment.JobApi.Features.JobVacancies.CreateJobVacancy;

public record CreateJobVacancyCommand(string Title, string Description, bool IsActive, Guid CompanyId) : ICommand<JobVacancy>;