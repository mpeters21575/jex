namespace Jex.Assessment.JobApi.Features.JobVacancies.UpdateJobVacancy;

public class UpdateJobVacancyHandler(ApplicationDbContext context, IValidator<UpdateJobVacancyCommand> validator)
    : IRequestHandler<UpdateJobVacancyCommand, JobVacancy>
{
    public async Task<JobVacancy> Handle(UpdateJobVacancyCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var jobVacancy = await context.JobVacancies.FindAsync([request.Id], cancellationToken);
        jobVacancy.Title = request.Title;
        jobVacancy.Description = request.Description;
        jobVacancy.IsActive = request.IsActive;

        context.JobVacancies.Update(jobVacancy);
        await context.SaveChangesAsync(cancellationToken);

        return jobVacancy;
    }
}