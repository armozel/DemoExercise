using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoExercise.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILogger<HomeController> logger) : base(logger)
        {
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
