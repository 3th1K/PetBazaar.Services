using Ethik.Utility.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace ProductService.Domain.Models;

public abstract class Product : IBaseEntity
{
    public string Id { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public bool? IsDeleted { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    [MaxLength(50)]
    public string? DescriptionShort { get; set; }

    [MaxLength(100)]
    public string? DescriptionMedium { get; set; }

    [MaxLength(500)]
    public string? DescriptionLarge { get; set; }
}