using System;
using Microsoft.Extensions.DependencyInjection;
using ExampleDDD.Infrastructure.CrossCutting;

namespace ExampleDDD.WebAPI.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            IoC.RegisterServices(services);
        }
    }
}
