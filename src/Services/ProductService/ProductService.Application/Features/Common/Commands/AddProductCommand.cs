namespace ProductService.Application.Features.Common.Commands;

/// <summary>
/// Represents a base command for adding a product.
/// </summary>
/// <remarks>
/// This abstract class provides common properties for adding different types of products.
/// </remarks>
public abstract class AddProductCommand
{
    /// <summary>
    /// Gets or sets the unique identifier of the category to which the product belongs.
    /// </summary>
    public string CategoryId { get; set; } = null!;

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