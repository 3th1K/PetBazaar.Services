using Ethik.Utility.Api.Validation;
using ProductService.Application.Features.Food.Commands;

namespace ProductService.Application.Features.Food.Validators;

/// <summary>
/// Validates the <see cref="AddFoodProductCommand"/> to ensure it meets the required criteria.
/// </summary>
public class AddFoodProductValidator : Validator<AddFoodProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AddFoodProductValidator"/> class.
    /// </summary>
    /// <remarks>
    /// This validator enforces the following rules:
    /// - Price must be greater than 0.
    /// - Name, CategoryId, DescriptionShort, DescriptionMedium, DescriptionLarge, and Ingredients must not be null or empty.
    /// </remarks>
    public AddFoodProductValidator()
    {
        AddRules(rule =>
        {
            rule.RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            rule.RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Name is required.");
            rule.RuleFor(p => p.CategoryId).NotEmpty().NotNull().WithMessage("Category ID is required.");
            rule.RuleFor(p => p.DescriptionShort).NotEmpty().NotNull().WithMessage("Short description is required.");
            rule.RuleFor(p => p.DescriptionMedium).NotEmpty().NotNull().WithMessage("Medium description is required.");
            rule.RuleFor(p => p.DescriptionLarge).NotEmpty().NotNull().WithMessage("Detailed description is required.");
            rule.RuleFor(p => p.Ingredients).NotEmpty().NotNull().WithMessage("Ingredients are required.");
        });
        
    }
}