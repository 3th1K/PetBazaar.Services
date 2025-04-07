using Ethik.Utility.Common.Extentions;
using Ethik.Utility.CQRS;
using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using InventoryService.Application.Extensions.Mappings;
using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared;

namespace InventoryService.Application.Handlers;

/// <summary>
/// Handles the <see cref="GetInventoriesQuery"/> to retrieve a list of inventory details.
/// </summary>
public sealed class GetInventoriesHandler : IRequestHandler<GetInventoriesQuery, OperationResult<List<InventoryDetails>>>
{
    private readonly ILogger<GetInventoriesHandler> _logger;
    private readonly IInventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetInventoriesHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="inventoryRepository">The repository used to access inventory data.</param>
    public GetInventoriesHandler(ILogger<GetInventoriesHandler> logger, IInventoryRepository inventoryRepository)
    {
        _logger = logger;
        _inventoryRepository = inventoryRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetInventoriesQuery"/> to retrieve a list of inventory details.
    /// </summary>
    /// <param name="request">The query containing parameters for filtering, sorting, and pagination.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="OperationResult{T}"/> containing a list of <see cref="InventoryDetails"/> if successful, 
    /// or an error response if the operation fails.
    /// </returns>
    public async Task<OperationResult<List<InventoryDetails>>> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        if (request.PageNumber is null || request.PageSize is null)
        {
            // Retrieve all inventories without pagination
            var result = await _inventoryRepository.GetAllAsync(cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                // Filter out deleted inventories if requested
                var inventories = request.IncludeDeleted ? result.Data : result.Data.Where(i => !i.IsDeleted);
                return OperationResult<List<InventoryDetails>>.Success(inventories.ToInventoryDetails().ToList());
            }
            return OperationResult<List<InventoryDetails>>.From(result);
        }
        else
        {
            // Retrieve inventories with pagination and sorting
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? 10;
            var ascending = request.Ascending ?? false;
            var orderByExp = ExpressionHelper.GetPropertyExpression<Inventory>(request.OrderBy);
            var result = await _inventoryRepository.GetAllAsync(pageNumber, pageSize, orderByExp, ascending, cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                // Filter out deleted inventories if requested
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<InventoryDetails>>.Success(result.Data.ToInventoryDetails().ToList());
            }
            return OperationResult<List<InventoryDetails>>.From(result);
        }
    }
}