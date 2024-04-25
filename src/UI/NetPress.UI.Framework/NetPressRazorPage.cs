using System.Text.Encodings.Web;
using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using NetPress.UI.Framework.ExtensionMethods.Common;

namespace NetPress.UI.Framework
{
    public abstract class NetPressRazorPage<TModel> : Microsoft.AspNetCore.Mvc.Razor.RazorPage<TModel>
    {
        /*
        public delegate Task<HtmlString> ViewComponentAsyncRenderer(string name, object? args = default);
        public delegate HtmlString ViewComponentRenderer(string name, object? args = default);

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
                    var serviceProvider = ViewContext.HttpContext.RequestServices;
                    var viewComponentHelper = new DefaultViewComponentHelper(
                        serviceProvider.GetRequiredService<IViewComponentDescriptorCollectionProvider>(),
                        HtmlEncoder.Default,
                        serviceProvider.GetRequiredService<IViewComponentSelector>(),
                        serviceProvider.GetRequiredService<IViewComponentInvokerFactory>(),
                        serviceProvider.GetRequiredService<IViewBufferScope>());

                    await using var stringWriter = new StringWriter();
                    viewComponentHelper.Contextualize(ViewContext);
                    var result = await viewComponentHelper.InvokeAsync(name, args);
                    result.WriteTo(stringWriter, HtmlEncoder.Default);
                    await stringWriter.FlushAsync();
                    return new HtmlString(stringWriter.ToString());
                };
                return _componentAsyncRenderer;
            }
        }

        /// <summary>
        /// Render a View Component Synchronously
        /// </summary>
        public ViewComponentRenderer VC => _componentRenderer ??= (name, args) => VCAsync(name, args).Result;
        */

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
