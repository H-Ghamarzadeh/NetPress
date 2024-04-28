using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.ViewComponents;

public class LatestPostsComponent(IHub hub) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(string? postType = null, int? pageSize = 8)
    {
        var model = await hub.RequestAsync(new GetLatestPostsListQuery(pageSize: pageSize, postType: postType));
        return View(model: model);
    }
}