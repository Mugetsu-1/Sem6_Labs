using Microsoft.AspNetCore.Mvc;

namespace Lab3._3.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
