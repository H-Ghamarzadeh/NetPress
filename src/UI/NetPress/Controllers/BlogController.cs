using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.Controllers
{
    public class BlogController(IHub hub) : Controller
    {
        [Route("blog/{page:int?}")]
        public async Task<IActionResult> Index(int? page, int? pageSize)
        {
            if (page <= 0 || pageSize <= 0 || pageSize > 500 )
            {
                RouteData.Values.Clear();
                return RedirectToAction("Index", "Blog");
            }

            var model = await hub.RequestAsync(new GetLatestPostsListQuery("post", pageSize, page));

            return View(model);
        }

        public async Task<IActionResult> Post(int? id)
        {
            if (id == null)
            {
                RouteData.Values.Clear();
                return RedirectToAction("Index", "Blog");
            }

            var model = await hub.RequestAsync(new GetPostDetailsQuery(id.Value));

            if (model == null)
            {
                RouteData.Values.Clear();
                return RedirectToAction("Index", "Blog");
            }

            return View(model);
        }
    }
}
