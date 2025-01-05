using System.Linq.Expressions;

namespace PetBazaar.Shared;

public static class ExpressionHelper
{
    public static Expression<Func<T, object>>? GetPropertyExpression<T>(string? propertyName)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return null;

        var parameter = Expression.Parameter(typeof(T), "x");
        var property = Expression.PropertyOrField(parameter, propertyName);
        var conversion = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(conversion, parameter);
    }
}

