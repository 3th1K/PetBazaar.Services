namespace ProductService.Application.Features.Common.Commands;

public abstract class AddProductCommand
{
    public string CategoryId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? DescriptionShort { get; set; }
    public string? DescriptionMedium { get; set; }
    public string? DescriptionLarge { get; set; }
}