using Microsoft.Extensions.DependencyInjection;
using PetBazaar.Shared.DependencyInjection;

namespace ProductService.Application.DependencyInjection;

/// <summary>
/// Provides extension methods for registering application-layer dependencies in the dependency injection container.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers application-layer services, including MediatR handlers and validators, in the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// This method registers:
    /// 1. MediatR handlers from the current assembly.
    /// 2. Validators from the current assembly using the shared dependency injection utilities.
    /// </remarks>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var thisAssembly = typeof(DependencyInjection).Assembly;

        // Register MediatR handlers from the current assembly
        services.AddMediatR(c => c.RegisterServicesFromAssembly(thisAssembly));

        // Register validators from the current assembly
        services.InjectValidatorsFromAssembly(thisAssembly);

        return services;
    }
}