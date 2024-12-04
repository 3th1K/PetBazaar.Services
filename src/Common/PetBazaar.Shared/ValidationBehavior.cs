using Ethik.Utility.Api.Exceptions;
using Ethik.Utility.Api.Models;
using FluentValidation;
using MediatR;

namespace PetBazaar.Shared;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null).Select(s => new ApiValidationFailure(s.PropertyName, s.ErrorMessage, s.AttemptedValue, s.FormattedMessagePlaceholderValues, s.Severity.ToString(), s.ErrorCode))
            .ToList();

        if (failures.Any())
        {
            throw new ApiValidationException(failures);
        }

        return await next();
    }
}