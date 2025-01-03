﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PetBazaar.Shared.DependencyInjection;
using FluentValidation;

namespace ProductService.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var thisAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(c => c.RegisterServicesFromAssembly(thisAssembly));
        services.InjectValidatorsFromAssembly(thisAssembly);
        return services;
    }
}