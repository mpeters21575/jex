using Jex.Assessment.JobApi.Features.Companies.DeleteCompany;
using Jex.Assessment.JobApi.Features.Companies.GetCompanies;
using Jex.Assessment.JobApi.Features.Companies.UpdateCompany;
using Jex.Assessment.JobApi.Features.JobVacancies.CreateJobVacancy;
using Jex.Assessment.JobApi.Features.JobVacancies.DeleteJobVacancy;
using Jex.Assessment.JobApi.Features.JobVacancies.GetJobVacancy;
using Jex.Assessment.JobApi.Features.JobVacancies.UpdateJobVacancy;

namespace Jex.Assessment.JobApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining<Program>();
                config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            }
        );
        services.AddValidatorsFromAssemblyContaining<CreateCompanyValidator>();

        return services;
    }

    public static IEndpointRouteBuilder AddEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("/api")
            .MapCreateCompanyEndpoint()
            .MapGetCompaniesEndpoint()
            .MapDeleteCompanyEndpoint()
            .MapUpdateCompanyEndpoint()
            .MapCreateJobVacancyEndpoint()
            .MapGetJobVacanciesEndpoint()
            .MapDeleteJobVacancyEndpoint()
            .MapUpdateJobVacancyEndpoint();
        return builder;
    }
}