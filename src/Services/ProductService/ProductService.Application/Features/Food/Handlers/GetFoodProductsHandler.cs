using Ethik.Utility.Common.Extentions;
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

public sealed class GetFoodProductsHandler : IRequestHandler<GetFoodProductsQuery, OperationResult<List<FoodProductDetails>>>
{
    private readonly ILogger<GetFoodProductsHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;

    public GetFoodProductsHandler(ILogger<GetFoodProductsHandler> logger, IFoodProductRepository foodProductRepository)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
    }

    public async Task<OperationResult<List<FoodProductDetails>>> Handle(GetFoodProductsQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        if (request.PageNumber is null || request.PageSize is null)
        {
            var result = await _foodProductRepository.GetAllAsync(cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<FoodProductDetails>>.Success(products.ToFoodProductDetails().ToList());
            }
            return OperationResult<List<FoodProductDetails>>.From(result);
        }
        else
        {
            var pageNumber = request.PageNumber ?? 1;
            var pageSize = request.PageSize ?? 10;
            var ascending = request.Ascending ?? false;
            var orderByExp = ExpressionHelper.GetPropertyExpression<FoodProduct>(request.OrderBy);
            var result = await _foodProductRepository.GetAllAsync(pageNumber, pageSize, orderByExp, ascending, cancellationToken);
            if (result.IsSuccess && result.Data is not null)
            {
                var products = request.IncludeDeleted ? result.Data : result.Data.Where(fProd => !fProd.IsDeleted);
                return OperationResult<List<FoodProductDetails>>.Success(products.ToFoodProductDetails().ToList());
            }
            return OperationResult<List<FoodProductDetails>>.From(result);
        }
    }
}