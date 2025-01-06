using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Ethik.Utility.Common.Extentions;
using InventoryService.Application.Extensions.Mappings;

namespace InventoryService.Application.Handlers;

public sealed class GetProductInventoryHandler : IRequestHandler<GetProductInventoryQuery, OperationResult<ProductInventoryDetails>>
{
    private readonly ILogger<GetProductInventoryHandler> _logger;
    private readonly IInventoryRepository _inventoryRepository;
    public GetProductInventoryHandler(ILogger<GetProductInventoryHandler> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }
    public async Task<OperationResult<ProductInventoryDetails>> Handle(GetProductInventoryQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        var result = await _inventoryRepository.FindAsync(i => i.ProductId==request.ProductId);
        if (result.IsSuccess && result.Data is not null)
        {
            var data = result.Data.Where(i => !i.IsDeleted);
            
            if(!data.Any())
                return OperationResult<ProductInventoryDetails>.Failure("Inventory for the product is unavailable", "product_inventory_unavailable");
            
            return OperationResult<ProductInventoryDetails>.Success(result.Data.ToProductInventoryDetails());
        }

        return OperationResult<ProductInventoryDetails>.From(result);
    }
}
