using Microsoft.AspNetCore.Mvc;

namespace TagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Tag Helpers Demo";
            return View();
        }
    }
}