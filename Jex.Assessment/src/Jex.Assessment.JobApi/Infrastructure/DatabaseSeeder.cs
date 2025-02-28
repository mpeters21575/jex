namespace Jex.Assessment.JobApi.Infrastructure;

public interface ISeeder
{
    Task SeedAsync(CancellationToken cancellationToken);
}

public class DatabaseSeeder(ApplicationDbContext context) : ISeeder
{
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await context.Database.MigrateAsync(cancellationToken);

        if (!await context.Companies.AnyAsync(cancellationToken: cancellationToken))
        {
            var companies = new List<Company>
            {
                new("Tech Corp", "123 Tech Street"),
                new("InnovateX", "456 Innovation Ave"),
                new("DevSoft", "789 Software Blvd"),
                new("Cloud Solutions", "101 Cloud Lane"),
                new("AI Systems", "202 AI Road"),
                new("Big Data Analytics", "303 Data Street"),
                new("Agile Development", "404 Agile Blvd"),
                new("FinTech Solutions", "505 Finance Ave"),
                new("CyberSecurity Experts", "606 Security Road"),
                new("E-Commerce Solutions", "707 E-Commerce St")
            };

            context.Companies.AddRange(companies);
            await context.SaveChangesAsync(cancellationToken);

            var jobTitles = new[]
            {
                "C# Developer", "Senior C# Developer", "Backend C# Developer", "Fullstack C# Developer",
                "Product Owner", "Senior Product Owner",
                "Scrum Master", "Agile Coach",
                "Software Team Lead", "Technical Team Lead",
                "Engineering Manager", "Development Manager", "IT Manager"
            };

            var descriptions = new[]
            {
                "Build and maintain .NET applications.",
                "Lead a team of developers to build scalable applications.",
                "Design and implement cloud-based solutions.",
                "Optimize software development processes.",
                "Ensure smooth software delivery with agile methodologies.",
                "Define and manage product vision and roadmap."
            };

            var random = new Random();
            var jobVacancies = new List<JobVacancy>();

            for (int i = 0; i < 50; i++)
            {
                var title = jobTitles[random.Next(jobTitles.Length)];
                var description = descriptions[random.Next(descriptions.Length)];
                var company = companies[random.Next(companies.Count)];

                jobVacancies.Add(new JobVacancy(title, description, true, company.Id, company));
            }

            context.JobVacancies.AddRange(jobVacancies);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}