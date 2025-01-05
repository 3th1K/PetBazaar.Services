using Ethik.Utility.Data.Results;
using MediatR;
using PetBazaar.Shared.Base.Queries;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Queries;

public class GetFoodProductsQuery : BasePagedQuery, IRequest<OperationResult<List<FoodProductDetails>>>
{
    public GetFoodProductsQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
        :base(includeDeleted, pageNumber, pageSize, orderBy, ascending)
    {
    }
}