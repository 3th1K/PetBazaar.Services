using Microsoft.Extensions.DependencyInjection;
using ProductService.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace ProductService.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        return services;
    }
}