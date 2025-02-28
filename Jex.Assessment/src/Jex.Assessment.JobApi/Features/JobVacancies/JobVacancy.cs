namespace Jex.Assessment.JobApi.Features.JobVacancies;

public class JobVacancy
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; }

    public JobVacancy()
    {
        
    }

    public JobVacancy(string title, string description, bool isActive, Guid companyId, Company company) : this()
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        IsActive = isActive;
        CompanyId = companyId;
        Company = company;
    }

    public void Update(string title, string description, bool isActive)
    {
        Title = title;
        Description = description;
        IsActive = isActive;
    }
}