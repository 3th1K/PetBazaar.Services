using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using MediatR;
using PetBazaar.Shared.Base.Queries;

namespace InventoryService.Application.Queries;

/// <summary>
/// Represents a query to retrieve a paginated and sorted list of inventory details.
/// </summary>
public class GetInventoriesQuery : BasePagedQuery, IRequest<OperationResult<List<InventoryDetails>>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetInventoriesQuery"/> class.
    /// </summary>
    /// <param name="includeDeleted">Whether to include deleted inventory items in the results. Defaults to <c>false</c>.</param>
    /// <param name="pageNumber">The page number for pagination. Defaults to <c>null</c> (no pagination).</param>
    /// <param name="pageSize">The number of items per page. Defaults to <c>null</c> (no pagination).</param>
    /// <param name="orderBy">The property name to order the results by. Defaults to <c>null</c> (no sorting).</param>
    /// <param name="ascending">Whether to sort the results in ascending order. Defaults to <c>null</c> (no sorting).</param>
    public GetInventoriesQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
        : base(includeDeleted, pageNumber, pageSize, orderBy, ascending)
    { }
}