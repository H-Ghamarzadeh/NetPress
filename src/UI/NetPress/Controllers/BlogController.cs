using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Exceptions;
using NetPress.Application.Features;
using NetPress.Domain.Constants;
using NetPress.Domain.Entities;

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

            var model = await hub.RequestAsync(new GetLatestPostsListQuery(PostsType.BlogPost, pageSize, page));

            return View(model);
        }

        [Authorize] 
        [Route("blog/{id:int?}")]
        [Route("blog/{slug?}")]
        [Route("blog/{id:int?}/{slug?}")]
        public async Task<IActionResult> Post(int? id, string? slug)
        {
            if (id == null && string.IsNullOrWhiteSpace(slug))
            {
                return RedirectToAction("Index", "Blog");
            }

            Post model;

            try
            {
                model = await hub.RequestAsync(new GetPostDetailsQuery(id, slug));
            }
            catch (EntityNotFoundException)
            {
                return NotFound();
            }

            return View(model);
        }

    }
}
