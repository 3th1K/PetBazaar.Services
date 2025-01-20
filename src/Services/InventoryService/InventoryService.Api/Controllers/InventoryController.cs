using Ethik.Utility.Api.Models;
using InventoryService.Application.Dtos;
using InventoryService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers;

[ApiController]
[Route("inventory")]
public class InventoryController : ControllerBase
{
    private readonly ILogger<InventoryController> _logger;
    private readonly IMediator _mediator;

    public InventoryController(ILogger<InventoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

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