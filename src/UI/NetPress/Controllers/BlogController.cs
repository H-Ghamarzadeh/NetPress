using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.Controllers
{
    public class BlogController(IHub hub) : Controller
    {
        [Route("blog")]
        [Route("blog/page/{page?}")]
        [Route("blog/category/{category}")]
        [Route("blog/category/{category}/page/{page?}")]
        public async Task<IActionResult> Index(int? page, int? pageSize, string category)
        {
            if (page <= 0 || pageSize <= 0 || pageSize > 500 )
            {
                RouteData.Values.Clear();
                return RedirectToAction("Index", "Blog");
            }

            var model = await hub.RequestAsync(new GetLatestPostsListQuery("blogpost", pageSize, page));

            return View(model);
        }

        [Route("blog/{id:int?}")]
        [Route("blog/{slug?}")]
        [Route("blog/{id:int?}/{slug?}")]
        public async Task<IActionResult> Post(int? id, string? slug)
        {
            if (id == null && string.IsNullOrWhiteSpace(slug))
            {
                RouteData.Values.Clear();
                return RedirectToAction("Index", "Blog");
            }

            var model = await hub.RequestAsync(new GetPostDetailsQuery(id, slug));

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
