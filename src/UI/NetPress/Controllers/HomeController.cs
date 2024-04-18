using Microsoft.AspNetCore.Mvc;
using NetPress.Application.Contracts.Persistence;
using NetPress.Models;
using System.Diagnostics;

namespace NetPress.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository postRepository;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository)
        {
            _logger = logger;
            this.postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await postRepository.GetAllAsync());
        }

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