namespace ProductService.Application.Features.Common.Queries;

/// <summary>
/// Represents a base query for retrieving details of a specific product.
/// </summary>
/// <remarks>
/// This abstract class provides a common structure for queries to retrieve details of different types of products.
/// </remarks>
public abstract class GetProductDetailsQuery
{
    /// <summary>
    /// Gets or sets the unique identifier of the product to retrieve.
    /// </summary>
    public string Id { get; set; } = null!;
}