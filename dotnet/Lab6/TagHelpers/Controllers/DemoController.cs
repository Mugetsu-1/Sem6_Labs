using Microsoft.AspNetCore.Mvc;
using TagHelpers.Models;

namespace TagHelpers.Controllers
{
    public class DemoController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            ViewData["Title"] = "Register";
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            ViewData["Title"] = "Register";
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            return RedirectToAction("Done", new { id = 7 });
        }

        public IActionResult Done(int id)
        {
            ViewData["Title"] = "Done";
            ViewData["Id"] = id;
            return View();
        }
    }
}