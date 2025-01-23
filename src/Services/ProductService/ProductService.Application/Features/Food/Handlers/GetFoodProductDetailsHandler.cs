using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Data.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using ProductService.Application.Extensions.Mappings;
using ProductService.Application.Features.Common.Constants;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Application.Features.Food.Queries;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;

namespace ProductService.Application.Features.Food.Handlers;

/// <summary>
/// Handles the <see cref="GetFoodProductDetailsQuery"/> to retrieve details of a specific food product.
/// </summary>
public sealed class GetFoodProductDetailsHandler : IRequestHandler<GetFoodProductDetailsQuery, OperationResult<FoodProductDetails>>
{
    private readonly ILogger<GetFoodProductDetailsHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetFoodProductDetailsHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="foodProductRepository">The repository used to retrieve food product data.</param>
    public GetFoodProductDetailsHandler(ILogger<GetFoodProductDetailsHandler> logger, IFoodProductRepository foodProductRepository)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetFoodProductDetailsQuery"/> to retrieve details of a specific food product.
    /// </summary>
    /// <param name="request">The query containing the unique identifier of the food product to retrieve.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="OperationResult{T}"/> containing the <see cref="FoodProductDetails"/> if successful,
    /// or an error response if the operation fails or the product is deleted.
    /// </returns>
    public async Task<OperationResult<FoodProductDetails>> Handle(GetFoodProductDetailsQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        OperationResult<FoodProduct> result = await _foodProductRepository.GetByIdAsync(request.Id, cancellationToken);

        // Check if the product is deleted
        if (result.IsSuccess && result.Data!.IsDeleted)
        {
            return OperationResult<FoodProductDetails>.Failure("Product is unavailable", ProductOperationErrors.ProductDeleted);
        }

        // Return the product details if the product is not deleted
        if (result.IsSuccess && !result.Data!.IsDeleted)
        {
            return OperationResult<FoodProductDetails>.Success(result.Data.ToFoodProductDetails());
        }

        // Return the result as-is if the operation was not successful
        return OperationResult<FoodProductDetails>.From(result);
    }
}