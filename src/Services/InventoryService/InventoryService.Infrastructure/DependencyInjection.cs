using Ethik.Utility.Messaging;
using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Consumers;
using InventoryService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using PetBazaar.Shared.Events;

namespace InventoryService.Infrastructure.DependencyInjection;

/// <summary>
/// Provides extension methods for registering infrastructure-layer dependencies in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure-layer services, including the database context, repositories, and MassTransit consumers.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// This method registers:
    /// 1. The <see cref="ApplicationDbContext"/> for database operations.
    /// 2. The <see cref="IInventoryRepository"/> implementation for inventory data access.
    /// 3. MassTransit with RabbitMQ configuration and the <see cref="ProductAddedConsumer"/> consumer.
    /// </remarks>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Register the database context factory
        services.AddDbContextFactory<ApplicationDbContext>();

        // Register the inventory repository
        services.AddSingleton<IInventoryRepository, InventoryRepository>();

        // Configure Messaging with RabbitMQ
        services.AddMessaging(cfg =>
        {
            cfg.AddConsumer<ProductAddedConsumer>();
            cfg.UseRabbitMQ(rabbitConfig =>
            {
                rabbitConfig.HostName = "localhost";
                rabbitConfig.Port = 5672;
                rabbitConfig.UserName = "guest";
                rabbitConfig.Password = "guest";
                rabbitConfig.ListeningQueues = ["queue.inventory"];
                rabbitConfig.PrefetchCount = 10;
                rabbitConfig.RetryPolicy = new RetryPolicy { MaxRetryAttempts = 5, BackoffExponent = 1.5, InitialDelay = TimeSpan.FromSeconds(1) };
                rabbitConfig.NumberOfWorkers = 5;
            });
        });

        return services;
    }
}