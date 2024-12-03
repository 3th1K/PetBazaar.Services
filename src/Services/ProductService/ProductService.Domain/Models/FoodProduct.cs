namespace ProductService.Domain.Models;

public class FoodProduct : Product
{
    public string Ingredients { get; set; } = null!;
}