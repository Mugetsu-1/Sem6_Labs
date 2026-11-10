using Microsoft.AspNetCore.Mvc;
using Models.Models;

namespace Models.Controllers
{
    public class BindingController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Model Binding Demo";
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create User";
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserBinding user)
        {
            ViewData["Title"] = "Create User";
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return View("Saved", user);
        }

        public IActionResult Route([FromRoute] int id)
        {
            ViewData["Title"] = "Route Data";
            ViewData["Id"] = id;
            return View();
        }

        public IActionResult Query([FromQuery] string q)
        {
            ViewData["Title"] = "Query String";
            ViewData["Q"] = q ?? "";
            return View();
        }
    }
}