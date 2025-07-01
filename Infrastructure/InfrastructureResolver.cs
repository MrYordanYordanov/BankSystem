using Infrastructure.Database.Unit;
using Infrastructure.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public static class InfrastructureResolver
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // 1. Register the DbContext
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<BankingDbContext>(options =>
            options.UseNpgsql(connectionString));

        // 2. Register the Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}