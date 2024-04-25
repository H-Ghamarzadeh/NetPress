using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.Controllers
{
    public class BlogController(IHub hub) : Controller
    {
        [Route("blog/{page?}")]
        public async Task<IActionResult> Index(int? page, int?pageSize)
        {
            var model = await hub.RequestAsync(new GetPostsListQuery() { PageIndex = page , PageSize = pageSize});
            return View(model);
        }

        public async Task<IActionResult> Post(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = await hub.RequestAsync(new GetPostDetailsQuery() { PostId = id.Value });
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
