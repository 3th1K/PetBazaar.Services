using Ethik.Utility.CQRS;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PetBazaar.Shared.DependencyInjection;

/// <summary>
/// Extension methods for configuring dependency injection within the PetBazaar application.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers validators from the specified assembly and configures the CQRS validation pipeline.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="assembly">The assembly containing the validators.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection InjectValidatorsFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }
}