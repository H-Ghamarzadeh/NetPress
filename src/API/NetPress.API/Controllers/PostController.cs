using Microsoft.AspNetCore.Mvc;

namespace NetPress.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
