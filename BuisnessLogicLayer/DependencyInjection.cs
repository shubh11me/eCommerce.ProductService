using Microsoft.Extensions.DependencyInjection;
using BuisnessLogicLayer.Services;
using BuisnessLogicLayer.Validations;

namespace BuisnessLogicLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBuisnessLogicLayerServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddTransient<ValidatorFactory>();
            return services;
        }
    }
}
