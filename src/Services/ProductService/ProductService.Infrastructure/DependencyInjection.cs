
using Ethik.Utility.Messaging;
using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain.Interfaces;
using ProductService.Infrastructure.Repositories;
using ProductService.Infrastructure.Services;

namespace ProductService.Infrastructure.DependencyInjection;

/// <summary>
/// Provides extension methods for registering infrastructure-layer dependencies in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure-layer services, including the database context, repositories, and MassTransit configuration.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// This method registers:
    /// 1. The <see cref="ApplicationDbContext"/> for database operations.
    /// 2. The <see cref="IFoodProductRepository"/> implementation for food product data access.
    /// 3. The <see cref="IEventPublisher"/> implementation using MassTransit.
    /// 4. MassTransit with RabbitMQ configuration.
    /// </remarks>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register the database context factory
        services.AddDbContextFactory<ApplicationDbContext>();

        // Register the food product repository
        services.AddSingleton<IFoodProductRepository, FoodProductRepository>();

        // Register the event publisher
        services.AddScoped<IEventPublisher, RabbitMqEventPublisher>();

        // Configure messaging with RabbitMQ
        services.AddMessaging(cfg =>
        {
            cfg.UseRabbitMQ(rabbitConfig =>
            {
                rabbitConfig.HostName = "localhost";
                rabbitConfig.Port = 5672;
                rabbitConfig.UserName = "guest";
                rabbitConfig.Password = "guest";
            });
        });

        return services;
    }
}