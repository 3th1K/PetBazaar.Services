using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Features.Common.Dtos;

/// <summary>
/// Represents a base request for adding a product.
/// </summary>
/// <remarks>
/// This abstract class provides common properties and validation rules for adding different types of products.
/// </remarks>
public abstract class AddProductRequest
{
    /// <summary>
    /// Gets or initializes the unique identifier of the category to which the product belongs.
    /// </summary>
    /// <remarks>
    /// This property is required and must not be null or empty.
    /// </remarks>
    [Required]
    public string CategoryId { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the name of the product.
    /// </summary>
    /// <remarks>
    /// This property is required and must not be null or empty.
    /// </remarks>
    [Required]
    public string Name { get; init; } = null!;

    /// <summary>
    /// Gets or initializes the price of the product.
    /// </summary>
    /// <remarks>
    /// This property is required and must be a valid decimal value.
    /// </remarks>
    [Required]
    public decimal Price { get; init; }

    /// <summary>
    /// Gets or initializes a short description of the product.
    /// </summary>
    /// <remarks>
    /// This property is optional and has a maximum length of 50 characters.
    /// </remarks>
    [MaxLength(50)]
    public string? DescriptionShort { get; init; }

    /// <summary>
    /// Gets or initializes a medium-length description of the product.
    /// </summary>
    /// <remarks>
    /// This property is optional and has a maximum length of 100 characters.
    /// </remarks>
    [MaxLength(100)]
    public string? DescriptionMedium { get; init; }

    /// <summary>
    /// Gets or initializes a detailed description of the product.
    /// </summary>
    /// <remarks>
    /// This property is optional and has a maximum length of 500 characters.
    /// </remarks>
    [MaxLength(500)]
    public string? DescriptionLarge { get; init; }
}