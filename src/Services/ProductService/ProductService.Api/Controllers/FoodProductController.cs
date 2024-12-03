using Ethik.Utility.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Food.Commands;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public FoodProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("food-product")]
    public async Task<IActionResult> AddAsync([FromBody] AddFoodProductRequest request)
    {
        var result = await _mediator.Send(new AddFoodProductCommand(request));

        if (result.IsSuccess && result.Data is not null)
        {
            var successResponse = ApiResponse<string>.Success(result.Data, 201, "Food product was added");
            return CreatedAtAction(nameof(Get), new { id = result.Data }, successResponse);
        }
        var response = ApiResponse<string>.Failure("Failed to add food product");
        return response.Result();
    }

    [HttpGet("food-product/{id}")]
    public IActionResult Get([FromRoute] string id)
    {
        return Ok();
    }
}