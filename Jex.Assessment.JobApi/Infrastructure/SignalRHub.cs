using Microsoft.AspNetCore.SignalR;

namespace Jex.Assessment.JobApi.Infrastructure;

public class SignalRHub : Hub
{
    public async Task SendCompanyUpdateNotification(Guid companyId)
    {
        await Clients.All.SendAsync("CompanyUpdated", companyId);
    }

    public async Task SendJobVacancyUpdateNotification(Guid jobVacancyId)
    {
        await Clients.All.SendAsync("JobVacancyUpdated", jobVacancyId);
    }
}