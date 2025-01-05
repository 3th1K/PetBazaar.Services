using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using MediatR;

namespace InventoryService.Application.Queries;

public class GetInventoriesQuery : IRequest<OperationResult<List<InventoryDetails>>>
{
    public bool IncludeDeleted { get; set; } = false;
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
    public string? OrderBy { get; set; }
    public bool? Ascending { get; set; }
    public GetInventoriesQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
    {
        IncludeDeleted = includeDeleted;
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderBy = orderBy;
        Ascending = ascending;
    }
}
