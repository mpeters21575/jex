namespace Jex.Assessment.JobApi.Features.JobVacancies;

public interface IJobVacancyRepository
{
    Task<JobVacancy?> GetByIdAsync(Guid jobVacancyId);
    Task<IEnumerable<JobVacancy>> GetAllAsync(Guid companyId);
    Task<JobVacancy> AddAsync(JobVacancy jobVacancy);
    Task<JobVacancy> UpdateAsync(JobVacancy jobVacancy);
    Task<bool> DeleteAsync(Guid jobVacancyId);
    Task<bool> ExistsAsync(Guid jobVacancyId);
    Task<bool> HasNoVacanciesAsync(Guid id, CancellationToken token);
}

public class JobVacancyRepository(ApplicationDbContext dbContext) : IJobVacancyRepository
{
    public async Task<JobVacancy?> GetByIdAsync(Guid jobVacancyId)
    {
        return await dbContext.JobVacancies
            .FirstOrDefaultAsync(j => j.Id == jobVacancyId);
    }

    public async Task<IEnumerable<JobVacancy>> GetAllAsync(Guid companyId)
    {
        return await dbContext.JobVacancies
            .Where(j => j.CompanyId == companyId)
            .ToListAsync();
    }

    public async Task<JobVacancy> AddAsync(JobVacancy jobVacancy)
    {
        await dbContext.JobVacancies.AddAsync(jobVacancy);
        await dbContext.SaveChangesAsync();
        return jobVacancy;
    }

    public async Task<JobVacancy> UpdateAsync(JobVacancy jobVacancy)
    {
        dbContext.JobVacancies.Update(jobVacancy);
        await dbContext.SaveChangesAsync();
        return jobVacancy;
    }

    public async Task<bool> DeleteAsync(Guid jobVacancyId)
    {
        var jobVacancy = await GetByIdAsync(jobVacancyId);
        if (jobVacancy == null)
        {
            return false;
        }

        dbContext.JobVacancies.Remove(jobVacancy);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(Guid jobVacancyId)
    {
        return await dbContext.JobVacancies
            .AnyAsync(j => j.Id == jobVacancyId);
    }
    
    public async Task<bool> HasNoVacanciesAsync(Guid id, CancellationToken token)
    {
        var vacancies = await dbContext.JobVacancies.Where(q=> q.CompanyId == id && q.IsActive).ToListAsync(token);
        return !vacancies.Any();
    }
}