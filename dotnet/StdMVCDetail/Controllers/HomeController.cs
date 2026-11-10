using Microsoft.AspNetCore.Mvc;

namespace StdMVCDetail.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
