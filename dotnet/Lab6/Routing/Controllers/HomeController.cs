using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Routing Home";
            return View();
        }

        // Attribute routing with a fixed template (no longer conventionally routed)
        [Route("welcome")]
        public IActionResult Welcome()
        {
            ViewData["Title"] = "Welcome";
            return View();
        }

        // Attribute routing with token replacement [controller] and [action]
        [Route("[controller]/[action]")]
        public IActionResult Token()
        {
            ViewData["Title"] = "Token Route";
            return View();
        }

        // HTTP verb attribute: only HTTP GET requests match
        [HttpGet("secure/info")]
        public IActionResult Info()
        {
            ViewData["Title"] = "Info (HttpGet)";
            return View();
        }
    }
}