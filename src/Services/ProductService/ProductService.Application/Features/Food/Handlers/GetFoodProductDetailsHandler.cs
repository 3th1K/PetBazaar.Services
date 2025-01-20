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

public sealed class GetFoodProductDetailsHandler : IRequestHandler<GetFoodProductDetailsQuery, OperationResult<FoodProductDetails>>
{
    private readonly ILogger<GetFoodProductDetailsHandler> _logger;
    private readonly IFoodProductRepository _foodProductRepository;

    public GetFoodProductDetailsHandler(ILogger<GetFoodProductDetailsHandler> logger, IFoodProductRepository foodProductRepository)
    {
        _logger = logger;
        _foodProductRepository = foodProductRepository;
    }

    public async Task<OperationResult<FoodProductDetails>> Handle(GetFoodProductDetailsQuery request, CancellationToken cancellationToken)
    {
        using var watch = _logger.Watch();
        OperationResult<FoodProduct> result = await _foodProductRepository.GetByIdAsync(request.Id, cancellationToken);
        if (result.IsSuccess && result.Data!.IsDeleted)
        {
            return OperationResult<FoodProductDetails>.Failure("Product is unavailable", ProductOperationErrors.ProductDeleted);
        }

        if (result.IsSuccess && !result.Data!.IsDeleted)
        {
            return OperationResult<FoodProductDetails>.Success(result.Data.ToFoodProductDetails());
        }

        return OperationResult<FoodProductDetails>.From(result);
    }
}