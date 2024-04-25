using HGO.Hub.Interfaces.Actions;
using Microsoft.AspNetCore.Builder;

namespace NetPress.Application.Actions
{
    public class BeforeAppRunAction(IApplicationBuilder applicationBuilder) : IAction
    {
        public IApplicationBuilder ApplicationBuilder { get; } = applicationBuilder;
    }
}
