using FluentValidation;
using ProductService.Application.Features.Food.Commands;

namespace ProductService.Application.Features.Food.Validators;

public class AddFoodProductValidator : AbstractValidator<AddFoodProductCommand>
{
    public AddFoodProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty().NotNull();
        RuleFor(p => p.CategoryId).NotEmpty().NotNull();
        RuleFor(p => p.DescriptionShort).NotEmpty().NotNull();
        RuleFor(p => p.DescriptionMedium).NotEmpty().NotNull();
        RuleFor(p => p.DescriptionLarge).NotEmpty().NotNull();
        RuleFor(p => p.Ingredients).NotEmpty().NotNull();
    }
}