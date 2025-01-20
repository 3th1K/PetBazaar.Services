using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using MediatR;
using PetBazaar.Shared.Base.Queries;

namespace InventoryService.Application.Queries;

public class GetInventoriesQuery : BasePagedQuery, IRequest<OperationResult<List<InventoryDetails>>>
{
    public GetInventoriesQuery(bool includeDeleted = false, int? pageNumber = null, int? pageSize = null, string? orderBy = null, bool? ascending = null)
        : base(includeDeleted, pageNumber, pageSize, orderBy, ascending)
    { }
}