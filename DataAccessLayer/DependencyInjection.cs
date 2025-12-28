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
            string conf = configuration.GetConnectionString("MySql")!;
            conf=conf.Replace("$MYSQL_PASSWORD", Environment.GetEnvironmentVariable("MYSQL_PASSWORD"))
            .Replace("$MYSQL_HOST", Environment.GetEnvironmentVariable("MYSQL_HOST"))
            .Replace("$MYSQL_PORT", Environment.GetEnvironmentVariable("MYSQL_PORT"))
            .Replace("$MYSQL_DB", Environment.GetEnvironmentVariable("MYSQL_DB"))
            .Replace("$MYSQL_USER", Environment.GetEnvironmentVariable("MYSQL_USER"));
            services.AddDbContext<Context.ApplicationDbContext>(options =>
                options.UseMySql(conf, ServerVersion.AutoDetect(conf))
            );

            services.AddTransient<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
