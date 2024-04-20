using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NetPress.Domain.Entities;

namespace NetPress.ViewComponents
{
    public class PostItemComponent(IHub hub) : ViewComponent
    {
        public IViewComponentResult Invoke(Post post)
        {
            return View(model: post);
        }
    }


    [HtmlTargetElement("PostItem")]
    public class PostItemTagHelper(IViewComponentHelper viewComponentHelper) : TagHelper
    {
        public Post Post { get; set; }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)viewComponentHelper).Contextualize(ViewContext);
            var content = await viewComponentHelper.InvokeAsync("PostItemComponent", new { post = Post });
            output.Content.SetHtmlContent(content);
        }
    }
}
