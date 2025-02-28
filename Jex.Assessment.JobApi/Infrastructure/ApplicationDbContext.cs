using Jex.Assessment.JobApi.Features.Companies;
using Jex.Assessment.JobApi.Features.JobVacancies;
using Microsoft.EntityFrameworkCore;

namespace Jex.Assessment.JobApi.Infrastructure;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<JobVacancy> JobVacancies { get; set; }
}

public class RepositoryUnitOfWork
{
    public ICompanyRepository CompanyRepository { get; }
    public IJobVacancyRepository JobVacancyRepository { get; }

    public RepositoryUnitOfWork(ICompanyRepository companyRepository, IJobVacancyRepository jobVacancyRepository)
    {
        CompanyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        JobVacancyRepository = jobVacancyRepository ?? throw new ArgumentNullException(nameof(jobVacancyRepository));
    }
}