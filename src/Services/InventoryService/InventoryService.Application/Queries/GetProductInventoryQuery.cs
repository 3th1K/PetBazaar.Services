using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using MediatR;

namespace InventoryService.Application.Queries;

public class GetProductInventoryQuery : IRequest<OperationResult<ProductInventoryDetails>>
{
    public string ProductId { get; }

    public GetProductInventoryQuery(string productId)
    {
        ProductId = productId;
    }
}