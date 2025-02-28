namespace Jex.Assessment.JobApi.Features.JobVacancies.UpdateJobVacancy;

public record UpdateJobVacancyCommand(Guid Id, string Title, string Description, bool IsActive) : ICommand<JobVacancy>;

