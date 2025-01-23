namespace ProductService.Application.Features.Common.Dtos;

/// <summary>
/// Represents a base class for detailed information about a product.
/// </summary>
/// <remarks>
/// This abstract class provides common properties for detailed information about different types of products.
/// </remarks>
public abstract class ProductDetails
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique identifier of the category to which the product belongs.
    /// </summary>
    public string CategoryId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the date and time when the product was created.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the product was last modified.
    /// </summary>
    public DateTime LastModified { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets a short description of the product.
    /// </summary>
    public string? DescriptionShort { get; set; }

    /// <summary>
    /// Gets or sets a medium-length description of the product.
    /// </summary>
    public string? DescriptionMedium { get; set; }

    /// <summary>
    /// Gets or sets a detailed description of the product.
    /// </summary>
    public string? DescriptionLarge { get; set; }
}