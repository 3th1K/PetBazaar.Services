using Ethik.Utility.Api.Exceptions;
using Ethik.Utility.Api.Models;
using Ethik.Utility.CQRS;
using FluentValidation;

namespace PetBazaar.Shared;

/// <summary>
/// CQRS pipeline behavior that validates requests using FluentValidation.
/// </summary>
public class ValidationBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationBehavior{TRequest, TResponse}"/> class.
    /// </summary>
    /// <param name="validators">A collection of validators for the request type.</param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Handles the specified request and executes the next step in the pipeline.
    /// </summary>
    /// <param name="request">The request to handle.</param>
    /// <param name="next">The next step in the pipeline.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The response from the next step in the pipeline.</returns>
    public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(s => new ApiValidationFailure(s.PropertyName, s.ErrorMessage, s.AttemptedValue, s.FormattedMessagePlaceholderValues, s.Severity.ToString(), s.ErrorCode))
            .ToList();

        if (failures.Any())
        {
            throw new ApiValidationException(failures);
        }

        return await next();
    }
}