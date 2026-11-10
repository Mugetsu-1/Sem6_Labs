using AzureProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AzureProject.Controllers
{
    public class HomeController : Controller
    {
        // In a real app this data would come from a database or an API.
        // Here it is hard-coded so the demo needs no external dependencies on Azure.
        private static readonly List<Product> Products = new()
        {
            new(1, "Azure App Service Plan", 0m),
            new(2, "Azure Resource Group", 0m),
            new(3, "ZIP Deploy Package", 0m)
        };

        public IActionResult Index()
        {
            return View(Products);
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
