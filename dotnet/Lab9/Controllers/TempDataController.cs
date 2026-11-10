using Microsoft.AspNetCore.Mvc;

namespace Lab9.Controllers;

public class TempDataController : Controller
{
    public IActionResult First()
    {
        return View();
    }

    public IActionResult Second()
    {
        return View();
    }

    public IActionResult Third()
    {
        return View();
    }
}
