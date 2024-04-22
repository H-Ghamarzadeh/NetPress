using System.Text.Encodings.Web;
using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace NetPress.UI.Framework
{
    public abstract class NetPressRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        public delegate Task<HtmlString> ViewComponentAsyncRenderer(string name, object? args);
        public delegate HtmlString ViewComponentRenderer(string name, object? args);

        private ViewComponentAsyncRenderer? _componentAsyncRenderer;
        private ViewComponentRenderer? _componentRenderer;

        /// <summary>
        /// Render a View Component Asynchronously
        /// </summary>
        public ViewComponentAsyncRenderer VA
        {
            get
            {
                _componentAsyncRenderer ??= async (name, args) =>
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
                return _componentAsyncRenderer;
            }
        }

        /// <summary>
        /// Render a View Component Synchronously
        /// </summary>
        public ViewComponentRenderer V => _componentRenderer ??= (name, args) => VA(name, args).Result;

        /// <summary>
        /// Access to Hub (for publish events, requests, ...)
        /// </summary>
        public IHub Hub => ViewContext.HttpContext.RequestServices.GetRequiredService<IHub>();

        /// <summary>
        /// Get current http request query strings
        /// </summary>
        public IQueryCollection QS => ViewContext.HttpContext.Request.Query;

        /// <summary>
        /// Get current http request form data
        /// </summary>
        public IFormCollection F => ViewContext.HttpContext.Request.Form;
    }
}
