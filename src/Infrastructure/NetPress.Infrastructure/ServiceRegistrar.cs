using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetPress.Application.Contracts.Plugins;
using NetPress.Infrastructure.Plugins;

namespace NetPress.Infrastructure
{
    public static class ServiceRegistrar
    {
        public static void AddNetPressInfrastructureServices(this IServiceCollection services, ConfigurationManager configurationManager)
        {
            services.AddScoped<IPluginManager, PluginManager>();
        }
    }
}
