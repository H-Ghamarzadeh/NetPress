using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetPress.Application.Contracts.Plugins;
using System;
using System.Text.Json;

namespace NetPress.Infrastructure.Plugins
{
    public class PluginManager(IConfiguration configuration, IHostEnvironment hostingEnvironment) : IPluginManager
    {
        private string GetPluginsBaseDirectory()
        {
            var pluginDirectory = configuration["Plugins:BaseDir"];
            if (!string.IsNullOrWhiteSpace(pluginDirectory))
            {

            }
            else
            {
                pluginDirectory = Path.Combine(hostingEnvironment.ContentRootPath, "Plugins");
            }

            if (!Directory.Exists(pluginDirectory))
            {
                Directory.CreateDirectory(pluginDirectory);
            }

            return pluginDirectory;
        }

        private async Task<List<PluginDescriptor>> GetAllPluginsDescriptor()
        {
            var pluginsDir = GetPluginsBaseDirectory();
            var pluginsDescriptorFiles = Directory.GetFiles(pluginsDir, "PluginDesc.txt");
            var result = new List<PluginDescriptor>();
            foreach (var descriptorFile in pluginsDescriptorFiles)
            {
                var pluginDescriptor = JsonSerializer.Deserialize<PluginDescriptor>(await File.ReadAllTextAsync(descriptorFile));

                if (pluginDescriptor != null && File.Exists(Path.Combine(Path.GetDirectoryName(descriptorFile) ?? throw new NullReferenceException(), pluginDescriptor.AssemblyName)))
                {
                    result.Add(pluginDescriptor);
                }
            }
            return result;
        }

        public async Task<List<PluginDescriptor>> GetPluginsAsync()
        {
            var result = await GetAllPluginsDescriptor();
            return result;
        }
    }
}
