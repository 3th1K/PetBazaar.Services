using System.Linq.Expressions;

namespace PetBazaar.Shared;

/// <summary>
/// Helper class for working with expressions, specifically for retrieving property expressions.
/// </summary>
public static class ExpressionHelper
{
    /// <summary>
    /// Creates an expression that represents accessing a specific property of the given type.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="propertyName">The name of the property to access.</param>
    /// <returns>An expression representing the property access, or null if the property name is null or empty.</returns>
    public static Expression<Func<T, object>>? GetPropertyExpression<T>(string? propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
        {
            return null;
        }

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.PropertyOrField(parameter, propertyName);
        var conversion = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(conversion, parameter);
    }
}