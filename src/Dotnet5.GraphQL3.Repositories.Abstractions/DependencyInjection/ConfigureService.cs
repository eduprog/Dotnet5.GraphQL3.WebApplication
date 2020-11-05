﻿using Dotnet5.GraphQL3.CrossCutting.Extensions;
using Dotnet5.GraphQL3.Repositories.Abstractions.UnitsOfWork;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace Dotnet5.GraphQL3.Repositories.Abstractions.DependencyInjection
{
    public static class ConfigureService
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.Scan(selector
                => selector
                    .FromApplicationDependencies(assembly
                        => assembly.FullName?.StartsWith(assembly.GetEntryAssemblySuffix()) ?? default)
                    .AddClasses(filter
                        => filter.AssignableToAny(typeof(IRepository<,>)))
                    .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                    .AsImplementedInterfaces()
                    .WithScopedLifetime());

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
            => services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}