using Ethik.Utility.Api.Models;
using InventoryService.Application.Dtos;
using InventoryService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers;

/// <summary>
/// Controller responsible for handling inventory-related operations.
/// </summary>
[ApiController]
[Route("inventory")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging.</param>
    /// <param name="mediator">The mediator used for handling queries.</param>
    public InventoryController(ILogger<InventoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves the inventory details for a specific product.
    /// </summary>
    /// <param name="productId">The ID of the product to retrieve inventory details for.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the product inventory details if successful, 
    /// or an error response if the operation fails.
    /// </returns>
    [HttpGet("product")]
    public async Task<IActionResult> GetProductInventoryAsync([FromQuery] string productId)
    {
        var result = await _mediator.Send(new GetProductInventoryQuery(productId));
        if (result.IsSuccess && result.Data is not null)
        {
            return ApiResponse<ProductInventoryDetails>.Success(result.Data, 200, "Fetched product inventory details").Result();
        }
        // TODO switch operation result error
        var response = ApiResponse<ProductInventoryDetails>.Failure("Failed to fetch product inventory");
        return response.Result();
    }

    /// <summary>
    /// Retrieves a list of all inventories, optionally paginated and sorted.
    /// </summary>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="orderBy">The field to order the results by.</param>
    /// <param name="ascending">Whether to sort the results in ascending order.</param>
    /// <param name="includeDeleted">Whether to include deleted inventories in the results.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the list of inventory details if successful, 
    /// or an error response if the operation fails.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(
    [FromQuery] int? pageNumber,
    [FromQuery] int? pageSize,
    [FromQuery] string? orderBy,
    [FromQuery] bool? ascending,
    [FromQuery] bool includeDeleted = false)
    {
        var result = await _mediator.Send(new GetInventoriesQuery(includeDeleted, pageNumber, pageSize, orderBy, ascending));
        if (result.IsSuccess && result.Data is not null)
        {
            return ApiResponse<List<InventoryDetails>>.Success(result.Data, 200, "Fetched inventories").Result();
        }
        // TODO switch operation result error
        var response = ApiResponse<List<InventoryDetails>>.Failure("Failed to fetch inventories");
        return response.Result();
    }
}