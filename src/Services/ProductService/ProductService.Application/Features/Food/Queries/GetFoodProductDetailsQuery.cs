using Ethik.Utility.CQRS;
using Ethik.Utility.Data.Results;
using ProductService.Application.Features.Common.Queries;
using ProductService.Application.Features.Food.Dtos;

namespace ProductService.Application.Features.Food.Queries;

/// <summary>
/// Represents a query to retrieve details of a specific food product.
/// </summary>
/// <remarks>
/// This query extends <see cref="GetProductDetailsQuery"/> to include additional properties specific to food products.
/// </remarks>
public class GetFoodProductDetailsQuery : GetProductDetailsQuery, IRequest<OperationResult<FoodProductDetails>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetFoodProductDetailsQuery"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the food product to retrieve.</param>
    public GetFoodProductDetailsQuery(string id)
    {
        Id = id;
    }
}