using Ethik.Utility.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Food.Commands;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Application.Features.Food.Queries;

namespace ProductService.Api.Controllers;

[ApiController]
[Route("food-product")]
public class FoodProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] AddFoodProductRequest request)
    {
        var result = await _mediator.Send(new AddFoodProductCommand(request));

        if (result.IsSuccess && result.Data is not null)
        {
            var successResponse = ApiResponse<string>.Success(result.Data, 201, "Food product was added");
            return successResponse.Result();
            // TODO return CreatedAtAction(nameof(GetAsync), new { id = "aa" }, successResponse);
        }
        var response = ApiResponse<string>.Failure("Failed to add food product");
        return response.Result();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        var result = await _mediator.Send(new GetFoodProductDetailsQuery(id));
        if (result.IsSuccess && result.Data is not null)
        {
            return ApiResponse<FoodProductDetails>.Success(result.Data, 200, "Fetched food product details").Result();
        }
        // TODO switch operation result error
        var response = ApiResponse<FoodProductDetails>.Failure("Failed to fetch food product");
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
        var result = await _mediator.Send(new GetFoodProductsQuery(includeDeleted, pageNumber, pageSize, orderBy, ascending));
        if (result.IsSuccess && result.Data is not null)
        {
            return ApiResponse<List<FoodProductDetails>>.Success(result.Data, 200, "Fetched food products").Result();
        }
        // TODO switch operation result error
        var response = ApiResponse<List<FoodProductDetails>>.Failure("Failed to fetch food products");
        return response.Result();
    }
}