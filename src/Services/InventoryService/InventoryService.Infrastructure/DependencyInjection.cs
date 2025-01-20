using InventoryService.Domain.Interfaces;
using InventoryService.Infrastructure.Consumers;
using InventoryService.Infrastructure.Repositories;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryService.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContextFactory<ApplicationDbContext>();
        services.AddSingleton<IInventoryRepository, InventoryRepository>();
        services.AddMassTransit(x =>
        {
            x.AddConsumer<ProductAddedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host("rabbitmq://localhost");

                cfg.ReceiveEndpoint("inventory-service", e =>
                {
                    e.ConfigureConsumer<ProductAddedConsumer>(context);

                    e.UseMessageRetry(r =>
                    {
                        r.Interval(3, TimeSpan.FromSeconds(5));
                    });

                    //e.DeadLetterExchange = "inventory-service-dlq";
                    //e.BindDeadLetterQueue("inventory-service-dlq");
                    //e.dead
                    //e.usede
                    //e.ConfigureDeadLetter(dl =>
                    //{
                    //    dl. "inventory-service-dlq";
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