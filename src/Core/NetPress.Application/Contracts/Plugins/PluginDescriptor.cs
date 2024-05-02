namespace NetPress.Application.Contracts.Plugins;

[Serializable]
public class PluginDescriptor
{
    public required string DisplayName { get; set; }
    public required string Description { get; set; }
    public required string AssemblyName { get; set; }
    public Version? Version { get; set; }
    public string? Logo { get; set; }
}