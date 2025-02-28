using Jex.Assessment.JobApi;
using Jex.Assessment.JobApi.Features.Companies.DeleteCompany;
using Jex.Assessment.JobApi.Features.Companies.GetCompanies;
using Jex.Assessment.JobApi.Features.Companies.UpdateCompany;
using Jex.Assessment.JobApi.Infrastructure.Middleware;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=jobportal.db"));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IJobVacancyRepository, JobVacancyRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Job API",
        Version = "v1",
        Description = "API for managing companies and job vacancies."
    });
});

builder.Services.Scan(scan => scan
    .FromAssemblyOf<ISeeder>()
    .AddClasses(classes => classes.AssignableTo<ISeeder>())
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
        var seeder = scope.ServiceProvider.GetRequiredService<ISeeder>();
        await seeder.SeedAsync(CancellationToken.None);
    }
}

app.UseCors("AllowAll");
app.AddEndpoints();
app.MapHub<SignalRHub>("/hubs/notifications");
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Job API v1");
        options.RoutePrefix = "";
    });
}

app.Run();