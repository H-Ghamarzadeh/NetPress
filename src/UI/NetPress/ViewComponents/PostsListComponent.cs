﻿using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NetPress.Domain.Entities;

namespace NetPress.ViewComponents
{
    public class PostsListComponent(IHub hub) : ViewComponent
    {
        public IViewComponentResult Invoke(List<Post>? posts)
        {
            if (posts == null) return Content("");

            return View(model: posts);
        }
    }


    [HtmlTargetElement("PostsList")]
    public class PostsListTagHelper(IViewComponentHelper viewComponentHelper) : TagHelper
    {
        public List<Post> Posts { get; set; }
        
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)viewComponentHelper).Contextualize(ViewContext);
            var content = await viewComponentHelper.InvokeAsync("PostsListComponent", new { posts = Posts });
            output.Content.SetHtmlContent(content);
        }
    }
}