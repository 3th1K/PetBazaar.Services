using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Consumers;
using InventoryService.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

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

        // Configure MassTransit with RabbitMQ
        services.AddMassTransit(x =>
        {
            // Register the ProductAddedConsumer
            x.AddConsumer<ProductAddedConsumer>();

            // Configure RabbitMQ
            x.UsingRabbitMq((context, cfg) =>
            {
                // Set the RabbitMQ host
                cfg.Host("rabbitmq://localhost");

                // Configure the receive endpoint for the inventory service
                cfg.ReceiveEndpoint("inventory-service", e =>
                {
                    // Configure the consumer
                    e.ConfigureConsumer<ProductAddedConsumer>(context);

                    // Configure message retry
                    e.UseMessageRetry(r =>
                    {
                        r.Interval(3, TimeSpan.FromSeconds(5));
                    });

                    // TODO: Configure dead-letter queue (DLQ) settings if needed
                    //e.DeadLetterExchange = "inventory-service-dlq";
                    //e.BindDeadLetterQueue("inventory-service-dlq");
                    //e.ConfigureDeadLetter(dl =>
                    //{
                    //    dl.QueueName = "inventory-service-dlq";
                    //    dl.RethrowFaultedMessages();
                    //    dl.UseDelayedRedelivery(r => r.Intervals(TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(30)));
                    //});
                });
            });
        });

        return services;
    }
}