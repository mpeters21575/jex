

namespace Jex.Assessment.JobApi.Features.JobVacancies.CreateJobVacancy;


public class CreateJobVacancyHandler(
    ICompanyRepository companyRepository,
    IJobVacancyRepository jobVacancyRepository, 
    IValidator<CreateJobVacancyCommand> validator)
    : IRequestHandler<CreateJobVacancyCommand, JobVacancy>
{
    public async Task<JobVacancy> Handle(CreateJobVacancyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var company = await companyRepository.GetByIdAsync(request.CompanyId);
        var jobVacancy = new JobVacancy(request.Title, request.Description, request.IsActive, request.CompanyId, company);

        await jobVacancyRepository.AddAsync(jobVacancy);

        return jobVacancy;
    }
}