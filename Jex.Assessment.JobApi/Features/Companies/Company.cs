namespace Jex.Assessment.JobApi.Features.Companies;

public class Company(string name, string address)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
}