using Ethik.Utility.CQRS;
using Ethik.Utility.Data.Results;
using PetBazaar.Shared.Base.Queries;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Queries;

/// <summary>
/// Represents a query to retrieve a paginated and sorted list of food products.
/// </summary>
/// <remarks>
/// This query extends <see cref="BasePagedQuery"/> to include parameters for filtering, sorting, and pagination.
/// </remarks>
public class GetFoodProductsQuery : BasePagedQuery, IRequest<OperationResult<List<FoodProductDetails>>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetFoodProductsQuery"/> class.
    /// </summary>
    /// <param name="includeDeleted">Whether to include deleted food products in the results. Defaults to <c>false</c>.</param>
    /// <param name="pageNumber">The page number for pagination. Defaults to <c>null</c> (no pagination).</param>
    /// <param name="pageSize">The number of items per page. Defaults to <c>null</c> (no pagination).</param>
    /// <param name="orderBy">The field to order the results by. Defaults to <c>null</c> (no sorting).</param>
    /// <param name="ascending">Whether to sort the results in ascending order. Defaults to <c>null</c> (no sorting).</param>
    public GetFoodProductsQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
        : base(includeDeleted, pageNumber, pageSize, orderBy, ascending)
    {
    }
}