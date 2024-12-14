using Ethik.Utility.Data.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Common.Queries;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Queries;

public class GetFoodProductsQuery : GetProductsQuery, IRequest<OperationResult<List<FoodProductDetails>>>
{
    public GetFoodProductsQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
    {
        IncludeDeleted = includeDeleted;
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        Ascending = ascending;
    }
}