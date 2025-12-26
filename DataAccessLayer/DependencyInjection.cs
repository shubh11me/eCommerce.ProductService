using DataAccessLayer.Repositories;
using DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            string conf = configuration.GetConnectionString("MySql");

            services.AddDbContext<Context.ApplicationDbContext>(options =>
                options.UseMySql(conf, ServerVersion.AutoDetect(conf))
            );

            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
