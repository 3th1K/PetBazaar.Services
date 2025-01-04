using MassTransit;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared.Events;

namespace InventoryService.Infrastructure.Consumers;

public class ProductAddedConsumer : IConsumer<ProductAdded>
{
    private readonly ILogger<ProductAddedConsumer> _logger;

    public ProductAddedConsumer(ILogger<ProductAddedConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ProductAdded> context)
    {
        //throw new NotImplementedException();
        var product = context.Message;

        _logger.LogInformation($"Received ProductAdded event for ProductId: {product.ProductId}");

        int initialStock = 0;
        _logger.LogInformation($"Stock initialized for ProductId: {product.ProductId} with {initialStock} units");

        //await context.Publish(new StockUpdated(product.ProductId, initialStock));
    }
}
