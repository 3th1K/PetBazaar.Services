using Ethik.Utility.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Models;

/// <summary>
/// Represents a base class for a product, providing common properties and validation rules.
/// </summary>
/// <remarks>
/// This abstract class implements <see cref="IBaseEntity"/> and includes properties and validation rules
/// common to all types of products.
/// </remarks>
public abstract class Product : IBaseEntity
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
    /// Gets or sets a value indicating whether the product is marked as deleted.
    /// </summary>
    public bool IsDeleted { get; set; }

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
    /// <remarks>
    /// This property is optional and has a maximum length of 50 characters.
    /// </remarks>
    [MaxLength(50)]
    public string? DescriptionShort { get; set; }

    /// <summary>
    /// Gets or sets a medium-length description of the product.
    /// </summary>
    /// <remarks>
    /// This property is optional and has a maximum length of 100 characters.
    /// </remarks>
    [MaxLength(100)]
    public string? DescriptionMedium { get; set; }

    /// <summary>
    /// Gets or sets a detailed description of the product.
    /// </summary>
    /// <remarks>
    /// This property is optional and has a maximum length of 500 characters.
    /// </remarks>
    [MaxLength(500)]
    public string? DescriptionLarge { get; set; }
}