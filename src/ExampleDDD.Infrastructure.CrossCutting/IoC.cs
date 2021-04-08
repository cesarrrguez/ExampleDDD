using Microsoft.Extensions.DependencyInjection;
using ExampleDDD.Domain.Common;
using ExampleDDD.Domain.Interfaces;
using ExampleDDD.Application.Services;
using ExampleDDD.Application.Interfaces;
using ExampleDDD.Infrastructure.Data.Context;
using ExampleDDD.Infrastructure.Data.Repositories;

namespace ExampleDDD.Infrastructure.CrossCutting
{
    public static class IoC
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Application
            services.AddScoped<IUserService, UserService>();

            // Infrastructure - Data
            services.AddScoped<IUnitOfWork, DataContext>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
