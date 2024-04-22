using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Domain.Entities;

namespace NetPress.ViewComponents
{
    public class PostsListComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Post>? posts)
        {
            if (posts == null) return Content("");

            return View(model: posts);
        }
    }
}
