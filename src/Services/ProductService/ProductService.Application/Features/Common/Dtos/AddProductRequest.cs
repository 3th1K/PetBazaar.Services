using System.ComponentModel.DataAnnotations;

namespace ProductService.Application.Features.Common.Dtos;

public abstract class AddProductRequest
{
    [Required]
    public string CategoryId { get; init; } = null!;

    [Required]
    public string Name { get; init; } = null!;

    [Required]
    public decimal Price { get; init; }

    [MaxLength(50)]
    public string? DescriptionShort { get; init; }

    [MaxLength(100)]
    public string? DescriptionMedium { get; init; }

    [MaxLength(500)]
    public string? DescriptionLarge { get; init; }
}