using Ethik.Utility.Common.Extentions;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared.Events;

namespace InventoryService.Infrastructure.Consumers;

public class ProductAddedConsumer : IConsumer<ProductAdded>
{
    private readonly ILogger<ProductAddedConsumer> _logger;
    private readonly IInventoryRepository _inventoryRepository;

    public ProductAddedConsumer(ILogger<ProductAddedConsumer> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }

    public async Task Consume(ConsumeContext<ProductAdded> context)
    {
        var product = context.Message;

        _logger.Information($"Received ProductAdded event for ProductId: {product.ProductId}");

        int initialStock = 0;

        var inventoryItem = new Inventory
        {
            ProductId = product.ProductId,
            BatchNumber = "InitialBatch",
            Quantity = initialStock,
            Location = "NonExistence"
        };
        var dbResult = await _inventoryRepository.AddAsync(inventoryItem);

        if (dbResult.IsSuccess)
            _logger.Information($"Stock initialized for ProductId: {product.ProductId} with {initialStock} units");
        else
            _logger.Error($"Unable to initialise stock for ProductId: {product.ProductId}");

        //await context.Publish(new StockUpdated(product.ProductId, initialStock));
    }
}