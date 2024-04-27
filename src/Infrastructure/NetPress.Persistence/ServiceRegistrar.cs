using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Application.Contracts.Persistence;
using NetPress.Persistence.Repository;

namespace NetPress.Persistence
{
    public static class ServiceRegistrar
    {
        public static void AddNetPressPersistenceServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddDbContext<NetPressDbContext>(cfg =>
            {
                switch (configurationManager["DataBase:Technology"]?.Trim().ToLower())
                {
                    case "sqlite":
                        cfg.UseSqlite(configurationManager["DataBase:ConnectionString"]);
                        break;
                    default:
                        cfg.UseSqlServer(configurationManager["DataBase:ConnectionString"]);
                        break;
                }
            });

            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
