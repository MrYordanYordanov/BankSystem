using Microsoft.Extensions.DependencyInjection;
using Services.ErrorHandling;
using Services.Reports;

namespace Services;

public static class ServiceResolver
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IGuard, Guard>();
        services.AddScoped<IReportingService, ReportingService>();
    }
}
