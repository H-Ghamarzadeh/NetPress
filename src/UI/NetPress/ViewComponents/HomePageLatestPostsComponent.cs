using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.ViewComponents;

public class HomePageLatestPostsComponent(IHub hub) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync([FromQuery] int? pageIndex)
    {
        var model = await hub.RequestAsync(new GetPostsListQuery() { PageSize = 20, PageIndex = pageIndex ?? 0 });
        return View(model: model);
    }
}