using Microsoft.Extensions.DependencyInjection;
using Repositories.Merchants;
using Repositories.Partners;
using Repositories.Transactions;

namespace Repositories;

public static class RepositoryResolver
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        services.AddScoped<IMerchantRepository, MerchantRepository>();
        services.AddScoped<ITransactionRepository, TransactionRepository>();
    }
}
