using System.Diagnostics;
using Lab8._2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab8._2.Controllers;

// Home page - links to the 4 CRUD sections
public class HomeController : Controller
{
    public IActionResult Index() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
