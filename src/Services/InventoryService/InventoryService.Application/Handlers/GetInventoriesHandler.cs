using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared;
using Ethik.Utility.Common.Extentions;
using InventoryService.Application.Extensions.Mappings;
using InventoryService.Domain.Models;

namespace InventoryService.Application.Handlers;

public sealed class GetInventoriesHandler : IRequestHandler<GetInventoriesQuery, OperationResult<List<InventoryDetails>>>
{
    private readonly ILogger<GetInventoriesHandler> _logger;
    private readonly IInventoryRepository _inventoryRepository;
    public GetInventoriesHandler(ILogger<GetInventoriesHandler> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }
    public async Task<OperationResult<List<InventoryDetails>>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        if (request.PageNumber is null || request.PageSize is null)
        {
            var result = await _inventoryRepository.GetAllAsync(cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                var inventories = request.IncludeDeleted ? result.Data : result.Data.Where(i => !i.IsDeleted);
                return OperationResult<List<InventoryDetails>>.Success(inventories.ToInventoryDetails().ToList());
            }
            return OperationResult<List<InventoryDetails>>.From(result);
        }
        else
        {
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? 10;
            var ascending = request.Ascending ?? false;
            var orderByExp = ExpressionHelper.GetPropertyExpression<Inventory>(request.OrderBy);
            var result = await _inventoryRepository.GetAllAsync(pageNumber, pageSize, orderByExp, ascending, cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<InventoryDetails>>.Success(result.Data.ToInventoryDetails().ToList());
            }
            return OperationResult<List<InventoryDetails>>.From(result);
        }
    }
}
