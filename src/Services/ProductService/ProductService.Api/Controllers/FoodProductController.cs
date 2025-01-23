using Ethik.Utility.Api.Models;
using Ethik.Utility.Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Api.Constants;
using ProductService.Application.Features.Common.Constants;
using ProductService.Application.Features.Food.Commands;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Application.Features.Food.Queries;

namespace ProductService.Api.Controllers;

/// <summary>
/// Controller for managing food product-related operations.
/// </summary>
[ApiController]
[Route("food-product")]
public class FoodProductController : ControllerBase
{
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodProductController"/> class.
    /// </summary>
    /// <param name="mediator">The mediator used to send commands and queries.</param>
    public FoodProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Adds a new food product.
    /// </summary>
    /// <param name="request">The request containing the details of the food product to add.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the result of the operation.
    /// Returns a 201 Created response if successful, or a failure response if the operation fails.
    /// </returns>
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

    /// <summary>
    /// Retrieves details of a specific food product.
    /// </summary>
    /// <param name="productId">The unique identifier of the food product to retrieve.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the food product details if successful,
    /// or a failure response if the operation fails or the product is not found.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAsync([FromQuery] string productId)
    {
        var result = await _mediator.Send(new GetFoodProductDetailsQuery(productId));
        if (result.IsSuccess && result.Data is not null)
        {
            return ApiResponse<FoodProductDetails>.Success(result.Data, 200, "Fetched food product details").Result();
        }
        var failureResponse = ApiResponse<FoodProductDetails>.Failure("Failed to fetch food product");

        if (result.MatchError(RepositoryErrorCodes.EntityNotFound))
            failureResponse = ApiResponse<FoodProductDetails>.Failure(ApiErrorConstants.ProductNotFound, $"Food product with id {productId} not found", 404);
        else if (result.MatchError(ProductOperationErrors.ProductDeleted))
            failureResponse = ApiResponse<FoodProductDetails>.Failure(ApiErrorConstants.ProductDeleted, $"Food product with id {productId} is unavailable", 404);

        return failureResponse.Result();
    }

    /// <summary>
    /// Retrieves a list of all food products, optionally paginated and sorted.
    /// </summary>
    /// <param name="pageNumber">The page number for pagination.</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <param name="orderBy">The field to order the results by.</param>
    /// <param name="ascending">Whether to sort the results in ascending order.</param>
    /// <param name="includeDeleted">Whether to include deleted food products in the results.</param>
    /// <returns>
    /// An <see cref="IActionResult"/> containing the list of food products if successful,
    /// or a failure response if the operation fails.
    /// </returns>
    [HttpGet("all")]
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