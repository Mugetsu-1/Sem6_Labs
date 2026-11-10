using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    public class OrderController : Controller
    {
        // Reached only through /order/{id} with the int constraint
        public IActionResult Id(int id)
        {
            ViewData["Title"] = "Order by Id";
            ViewData["Id"] = id;
            return View();
        }

        // Reached only through /code/{code} with the 3-digit regex constraint
        public IActionResult Code(string code)
        {
            ViewData["Title"] = "Order by Code";
            ViewData["Code"] = code;
            return View();
        }
    }
}