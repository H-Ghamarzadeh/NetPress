using System.Text.Encodings.Web;
using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.Extensions.Primitives;
using NetPress.UI.Framework.ExtensionMethods.Common;

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
        public ViewComponentAsyncRenderer VCAsync
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
        public ViewComponentRenderer VC => _componentRenderer ??= (name, args) => VCAsync(name, args).Result;

        /// <summary>
        /// Access to Hub (for publish events, requests, ...)
        /// </summary>
        public IHub Hub => ViewContext.HttpContext.RequestServices.GetRequiredService<IHub>();

        /// <summary>
        /// Get value of the specified key from the current http request query strings and convert it to typeof(T)
        /// </summary>
        public T Query<T>(string key, T defaultValue = default(T)) => ViewContext.HttpContext.Request.Query[key].ToString().To<T>(defaultValue);

        /// <summary>
        /// Get value of the specified key from the current http request query strings as string
        /// </summary>
        public string Query(string key) => Query(key, "");

        /// <summary>
        /// Get value of the specified key from the current http request form data and convert it to typeof(T)
        /// </summary>
        public T Form<T>(string key, T defaultValue = default(T)) => ViewContext.HttpContext.Request.Form[key].ToString().To<T>(defaultValue);

        /// <summary>
        /// Get value of the specified key from the current http request form data as string
        /// </summary>
        public string Form(string key) => Form(key, "");
    }
}
