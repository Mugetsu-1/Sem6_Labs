using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class ProductController : Controller
    {
        // Reached through /products/{category?} (optional parameter)
        public IActionResult List(string? category)
        {
            ViewData["Title"] = "Products";
            ViewData["Category"] = category ?? "all";
            return View();
        }

        // Attribute routing with an inline int constraint
        [HttpGet("product/{id:int}")]
        public IActionResult Show(int id)
        {
            ViewData["Title"] = "Product Detail";
            ViewData["Id"] = id;
            return View();
        }
    }
}