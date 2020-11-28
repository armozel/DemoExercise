using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoExercise.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly ILogger<Controller> _logger;

        protected BaseController(ILogger<Controller> logger)
        {
            _logger = logger;
        }
    }
}
