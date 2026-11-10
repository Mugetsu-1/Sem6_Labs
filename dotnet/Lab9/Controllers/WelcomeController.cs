using Microsoft.AspNetCore.Mvc;
using Lab9.Models;

namespace Lab9.Controllers;

public class WelcomeController : Controller
{
    // Session: set data
    public IActionResult Index()
    {
        HttpContext.Session.SetString("Name", "Saugat Bikram Thapa");
        HttpContext.Session.SetInt32("Age", 21);
        return View();
    }

    // Session: read data (in Get view)
    public IActionResult Get()
    {
        return View();
    }

    // Query String: /Welcome/GetQueryString?name=Saugat&age=30
    public IActionResult GetQueryString(string name, int age)
    {
        User newUser = new User()
        {
            Name = name,
            Age = age
        };
        return View(newUser);
    }

    // Hidden Field: show form with hidden Id
    [HttpGet]
    public IActionResult SetHiddenFieldValue()
    {
        User newUser = new User()
        {
            Id = 101,
            Name = "John",
            Age = 31
        };
        return View(newUser);
    }

    // Hidden Field: hidden Id comes back in the form post
    [HttpPost]
    public IActionResult SetHiddenFieldValue(IFormCollection keyValues)
    {
        var id = keyValues["Id"];
        return Content($"Hidden Id received: {id}");
    }
}
