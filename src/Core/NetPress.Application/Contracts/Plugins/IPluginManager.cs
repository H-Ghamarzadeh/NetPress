namespace NetPress.Application.Contracts.Plugins
{
    public interface IPluginManager
    {
        Task<List<PluginDescriptor>> GetPluginsAsync();
    }
}
