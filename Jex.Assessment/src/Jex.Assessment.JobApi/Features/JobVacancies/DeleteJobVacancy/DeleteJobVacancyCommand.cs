namespace Jex.Assessment.JobApi.Features.JobVacancies.DeleteJobVacancy;

public record DeleteJobVacancyCommand(Guid Id) : ICommand<bool>;