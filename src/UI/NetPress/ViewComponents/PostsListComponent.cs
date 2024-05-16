using Microsoft.AspNetCore.Mvc;
using NetPress.Domain.Entities;

namespace NetPress.ViewComponents
{
    public class PostsListComponent : ViewComponent
    {
        public IViewComponentResult Invoke(List<Post> posts, int? colPerRow = 3)
        {
            if (posts.Count == 0) return Content("");

            if (colPerRow <= 0) colPerRow = 1;
            else if (colPerRow > 12) colPerRow = 12;
            ViewData["ColPerRow"] = colPerRow;

            return View(model: posts);
        }

    }
}
