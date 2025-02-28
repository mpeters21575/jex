using Jex.Assessment.JobApi.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Jex.Assessment.JobApi.Features.Companies;

public interface ICompanyRepository
{
    Task<Company?> GetByIdAsync(Guid companyId);
    Task<IEnumerable<Company>> GetAllAsync();
    Task<Company> AddAsync(Company company);
    Task<Company?> UpdateAsync(Guid companyId, string name, string address);
    Task<bool> DeleteAsync(Guid companyId);
    Task<bool> ExistsAsync(string name, CancellationToken token);
    Task<bool> ExistsAsync(Guid name, CancellationToken token);
}

public class CompanyRepository(ApplicationDbContext dbContext) : ICompanyRepository
{
    public async Task<Company?> GetByIdAsync(Guid companyId)
    {
        return await dbContext.Companies
            .FirstOrDefaultAsync(c => c.Id == companyId);
    }

    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        var vacancies = await dbContext.JobVacancies.ToListAsync();
        var ids = vacancies.Where(vacancy => vacancy.IsActive).Select(q => q.CompanyId).Distinct();
        var companies = await dbContext.Companies
            .Where(c => ids.Contains(c.Id))
            .ToListAsync();
        return companies;
    }

    public async Task<Company> AddAsync(Company company)
    {
        await dbContext.Companies.AddAsync(company);
        await dbContext.SaveChangesAsync();
        return company;
    }

    public async Task<Company?> UpdateAsync(Guid companyId, string name, string address)
    {
        var company = await GetByIdAsync(companyId);
        if (company is not null)
        {
            company.Name = name;
            company.Address = address;
            
            dbContext.Companies.Update(company);
            await dbContext.SaveChangesAsync();
            return company;
        }

        return null;
    }

    public async Task<bool> DeleteAsync(Guid companyId)
    {
        var company = await GetByIdAsync(companyId);
        if (company == null)
        {
            return false;
        }

        dbContext.Companies.Remove(company);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string name, CancellationToken token)
    {
        var result = await dbContext.Companies
            .AnyAsync(c => c.Name == name, token);
        return result;
    }

    public async Task<bool> ExistsAsync(Guid id, CancellationToken token)
    {
        var result = await GetByIdAsync(id);
        return result is not null;
    }
}