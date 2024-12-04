using FluentValidation;
using ProductService.Application.Features.Food.Commands;

namespace ProductService.Application.Features.Food.Validators;

public class AddFoodProductValidator : AbstractValidator<AddFoodProductCommand>
{
    public AddFoodProductValidator()
    {
        RuleFor(p => p.Price).GreaterThan(0);
    }
}