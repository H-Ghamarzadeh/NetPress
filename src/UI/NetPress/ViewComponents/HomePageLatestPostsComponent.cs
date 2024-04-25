using HGO.Hub.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Features;

namespace NetPress.ViewComponents;

public class HomePageLatestPostsComponent(IHub hub) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(int? pageSize)
    {
        var model = await hub.RequestAsync(new GetPostsListQuery() { PageSize = pageSize ?? 8});
        return View(model: model);
    }
}