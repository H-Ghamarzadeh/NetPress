using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NetPress.Application.Features.Post.Queries.GetPostsList;

namespace NetPress.ViewComponents
{
    public class PostsListComponent(IHub hub) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string param)
        {
            var model = await hub.RequestAsync(new GetPostsList());
            return View(model:param);
        }
    }


    [HtmlTargetElement("PostsList")]
    public class PostsListTagHelper(IViewComponentHelper viewComponentHelper) : TagHelper
    {
        public string? Param { get; set; }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            //IViewContextAware: Contract for contextualizing a property activated by a view with the ViewContext.
            //Contextualize: Contextualizes the instance with the specified viewContext.
            ((IViewContextAware)viewComponentHelper).Contextualize(ViewContext);
            var content = await viewComponentHelper.InvokeAsync("PostsListComponent", new { param = Param });
            output.Content.SetHtmlContent(content);
        }
    }
}
