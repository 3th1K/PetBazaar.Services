using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using InventoryService.Application.Extensions.Mappings;
using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace InventoryService.Application.Handlers;

/// <summary>
/// Handles the <see cref="GetProductInventoryQuery"/> to retrieve inventory details for a specific product.
/// </summary>
public sealed class GetProductInventoryHandler : IRequestHandler<GetProductInventoryQuery, OperationResult<ProductInventoryDetails>>
{
    private readonly ILogger<GetProductInventoryHandler> _logger;
    private readonly IInventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductInventoryHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="inventoryRepository">The repository used to access inventory data.</param>
    public GetProductInventoryHandler(ILogger<GetProductInventoryHandler> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetProductInventoryQuery"/> to retrieve inventory details for a specific product.
    /// </summary>
    /// <param name="request">The query containing the product ID for which inventory details are requested.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="OperationResult{T}"/> containing the <see cref="ProductInventoryDetails"/> for the specified product if successful, 
    /// or an error response if the operation fails or no inventory is found.
    /// </returns>
    public async Task<OperationResult<ProductInventoryDetails>> Handle(GetProductInventoryQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        var result = await _inventoryRepository.FindAsync(i => i.ProductId == request.ProductId);
        if (result.IsSuccess && result.Data is not null)
        {
            // Filter out deleted inventory items
            var data = result.Data.Where(i => !i.IsDeleted);

            // Return a failure response if no inventory is available for the product
            if (!data.Any())
                return OperationResult<ProductInventoryDetails>.Failure("Inventory for the product is unavailable", "product_inventory_unavailable");

            // Map the inventory data to ProductInventoryDetails and return a success response
            return OperationResult<ProductInventoryDetails>.Success(result.Data.ToProductInventoryDetails());
        }

        // Return the result as-is if the operation was not successful
        return OperationResult<ProductInventoryDetails>.From(result);
    }
}