using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NetPress.Application.Contracts.Plugins;
using NetPress.ViewModels;
using NetPress.Infrastructure.Plugins;

namespace NetPress.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IPluginManager pluginManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var a = await pluginManager.GetPluginsAsync();
            logger.Log(LogLevel.Trace, "Loading Home Page");
            return View();
        }

        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = Int32.MaxValue)]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}