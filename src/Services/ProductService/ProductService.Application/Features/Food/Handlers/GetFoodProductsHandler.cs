﻿using Ethik.Utility.Common.Extentions;
using Ethik.Utility.Data.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using PetBazaar.Shared;
using ProductService.Application.Extensions.Mappings;
using ProductService.Application.Features.Food.Dtos;
using ProductService.Application.Features.Food.Queries;
using ProductService.Domain.Interfaces;
using ProductService.Domain.Models;

namespace ProductService.Application.Features.Food.Handlers;

/// <summary>
/// Handles the <see cref="GetFoodProductsQuery"/> to retrieve a list of food products.
/// </summary>
public sealed class GetFoodProductsHandler : IRequestHandler<GetFoodProductsQuery, OperationResult<List<FoodProductDetails>>>
{
    private readonly ILogger<GetFoodProductsHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetFoodProductsHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger used for logging operations.</param>
    /// <param name="foodProductRepository">The repository used to retrieve food product data.</param>
    public GetFoodProductsHandler(ILogger<GetFoodProductsHandler> logger, IFoodProductRepository foodProductRepository)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
    }

    /// <summary>
    /// Handles the <see cref="GetFoodProductsQuery"/> to retrieve a list of food products.
    /// </summary>
    /// <param name="request">The query containing parameters for filtering, sorting, and pagination.</param>
    /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
    /// <returns>
    /// An <see cref="OperationResult{T}"/> containing a list of <see cref="FoodProductDetails"/> if successful,
    /// or an error response if the operation fails.
    /// </returns>
    public async Task<OperationResult<List<FoodProductDetails>>> Handle(GetFoodProductsQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();

        // Handle non-paginated request
        if (request.PageNumber is null || request.PageSize is null)
        {
            var result = await _foodProductRepository.GetAllAsync(cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                // Filter out deleted products if requested
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<FoodProductDetails>>.Success(products.ToFoodProductDetails().ToList());
            }
            return OperationResult<List<FoodProductDetails>>.From(result);
        }
        // Handle paginated request
        else
        {
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? 10;
            var ascending = request.Ascending ?? false;
            var orderByExp = ExpressionHelper.GetPropertyExpression<FoodProduct>(request.OrderBy);

            // Retrieve paginated and sorted products
            var result = await _foodProductRepository.GetAllAsync(pageNumber, pageSize, orderByExp, ascending, cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                // Filter out deleted products if requested
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<FoodProductDetails>>.Success(products.ToFoodProductDetails().ToList());
            }
            return OperationResult<List<FoodProductDetails>>.From(result);
        }
    }
}