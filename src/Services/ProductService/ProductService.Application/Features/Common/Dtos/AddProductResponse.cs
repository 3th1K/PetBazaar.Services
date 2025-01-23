namespace ProductService.Application.Features.Common.Dtos;

/// <summary>
/// Represents a base response returned after successfully adding a product.
/// </summary>
/// <remarks>
/// This abstract class provides a common structure for responses when adding different types of products.
/// </remarks>
public abstract class AddProductResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly added product.
    /// </summary>
    public string Id { get; set; } = null!;
}