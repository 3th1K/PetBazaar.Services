namespace ProductService.Application.Features.Common.Dtos;

public abstract class ProductDetails
{
    public string Id { get; set; } = null!;
    public string CategoryId { get; set; } = null!;
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? DescriptionShort { get; set; }
    public string? DescriptionMedium { get; set; }
    public string? DescriptionLarge { get; set; }
}