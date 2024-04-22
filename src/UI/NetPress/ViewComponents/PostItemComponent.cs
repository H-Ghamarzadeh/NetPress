using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
}
