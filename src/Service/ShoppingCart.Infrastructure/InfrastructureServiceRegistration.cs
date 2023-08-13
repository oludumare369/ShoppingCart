using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Domain.Contracts;
using ShoppingCart.Infrastructure.Repositories;

namespace ShoppingCart.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            return services;
        }
    }
}
