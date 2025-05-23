﻿using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Messaging;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared.Events;

namespace InventoryService.Infrastructure.Consumers;

/// <summary>
/// Consumes the <see cref="ProductAdded"/> event to initialize inventory for a newly added product.
/// </summary>
public class ProductAddedConsumer : IMessageConsumer<ProductAdded>
{
    private readonly ILogger<ProductAddedConsumer> _logger;
    private readonly IInventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductAddedConsumer"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="inventoryRepository">The repository used to manage inventory data.</param>
    public ProductAddedConsumer(ILogger<ProductAddedConsumer> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }

    public async Task<bool> ConsumeAsync(ProductAdded message, IMessageContext context, CancellationToken token)
    {
        var product = message;

        _logger.Information($"Received ProductAdded event for ProductId: {product.ProductId}");

        int initialStock = 0;

        // Create a new inventory item for the product
        var inventoryItem = new Inventory
        {
            ProductId = product.ProductId,
            BatchNumber = "InitialBatch",
            Quantity = initialStock,
            Location = "NonExistence"
        };

        // Add the inventory item to the repository
        var dbResult = await _inventoryRepository.AddAsync(inventoryItem);

        if (dbResult.IsSuccess)
        {
            _logger.Information($"Stock initialized for ProductId: {product.ProductId} with {initialStock} units");
            return true;
        }
        else
        {
            _logger.Error($"Unable to initialize stock for ProductId: {product.ProductId}");
            return false;
        }

        // Publish a StockUpdated event if needed
        //await context.Publish(new StockUpdated(product.ProductId, initialStock));
    }
}