using Ethik.Utility.Api.Models;
using InventoryService.Application.Dtos;
using InventoryService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{

    private readonly ILogger<InventoryController> _logger;
    private readonly IMediator _mediator;

    public InventoryController(ILogger<InventoryController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
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
