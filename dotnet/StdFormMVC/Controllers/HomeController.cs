using Microsoft.AspNetCore.Mvc;
using StdFormMVC.Models;
using System.Diagnostics;

namespace StdFormMVC.Controllers
{
    public class HomeController : Controller
    {
        private static List<Student> Students = new List<Student>();

        public IActionResult Index()
        {
            return View(Students);
        }

        [HttpPost]
        public IActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            {
                Students.Add(s);
                return RedirectToAction("Index");
            }
            return View(Students);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
