using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>();
        services.AddSingleton<IInventoryRepository, InventoryRepository>();
        return services;
    }
}
  