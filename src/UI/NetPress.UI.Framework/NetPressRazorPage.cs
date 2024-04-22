using System.Text.Encodings.Web;
using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace NetPress.UI.Framework
{
    public abstract class NetPressRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        public delegate Task<HtmlString> ViewComponentRenderer(string name, object? args);

        private ViewComponentRenderer? _componentRenderer;

        public ViewComponentRenderer V
        {
            get
            {
                _componentRenderer ??= async (name, args) =>
                {
                    var service = ViewContext.HttpContext.RequestServices;
                    var helper = new DefaultViewComponentHelper(
                        service.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
                        HtmlEncoder.Default,
                        service.GetRequiredService<IViewComponentSelector>(),
                        service.GetRequiredService<IViewComponentInvokerFactory>(),
                        service.GetRequiredService<IViewBufferScope>());

                    await using var writer = new StringWriter();
                    helper.Contextualize(ViewContext);
                    var result = await helper.InvokeAsync(name, args);
                    result.WriteTo(writer, HtmlEncoder.Default);
                    await writer.FlushAsync();
                    return new HtmlString(writer.ToString());
                };
                return _componentRenderer;
            }
        }

        public IHub Hub
        {
            get
            {
                return ViewContext.HttpContext.RequestServices.GetRequiredService<IHub>();
            }
        }
    }
}
