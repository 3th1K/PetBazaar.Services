using FluentValidation;
using InventoryService.Application.Queries;

namespace InventoryService.Application.Validators;

public class GetInventoriesQueryValidator : AbstractValidator<GetInventoriesQuery>
{
    public GetInventoriesQueryValidator()
    {
        // Allowed fields for ordering
        var allowedFields = new[] { "Created", "LastModified", "ProductId", "BatchNumber", "ManufacturingDate", "ExpirationDate", "Quantity", "Location" };

        RuleFor(query => query.OrderBy)
            .Must(orderBy => string.IsNullOrEmpty(orderBy) || allowedFields.Contains(orderBy, StringComparer.OrdinalIgnoreCase))
            .WithMessage(query => $"Invalid 'OrderBy' field '{query.OrderBy}'. Allowed fields are: {string.Join(", ", allowedFields)}");
    }
}