using Ethik.Utility.Data.Results;
using InventoryService.Application.Dtos;
using MediatR;

namespace InventoryService.Application.Queries;

/// <summary>
/// Represents a query to retrieve inventory details for a specific product.
/// </summary>
public class GetProductInventoryQuery : IRequest<OperationResult<ProductInventoryDetails>>
{
    /// <summary>
    /// Gets the unique identifier of the product for which inventory details are requested.
    /// </summary>
    public string ProductId { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductInventoryQuery"/> class.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    public GetProductInventoryQuery(string productId)
    {
        ProductId = productId;
    }
}