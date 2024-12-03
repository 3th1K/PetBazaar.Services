using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>();
        services.AddSingleton<IFoodProductRepository, FoodProductRepository>();
        return services;
    }
}