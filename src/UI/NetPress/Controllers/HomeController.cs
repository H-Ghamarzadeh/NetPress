using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NetPress.ViewModels;

namespace NetPress.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public IActionResult Index()
        {
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