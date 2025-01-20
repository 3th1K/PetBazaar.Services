using Ethik.Utility.Data.Results;
using MediatR;
using ProductService.Application.Features.Common.Queries;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Queries;

public class GetFoodProductDetailsQuery : GetProductDetailsQuery, IRequest<OperationResult<FoodProductDetails>>
{
    public GetFoodProductDetailsQuery(string id)
    {
        Id = id;
    }
}