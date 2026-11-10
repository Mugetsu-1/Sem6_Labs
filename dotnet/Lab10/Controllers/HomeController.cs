using Lab10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab10.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> userMgr)
        {
            userManager = userMgr;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Secured resource: only the authenticated (registered) user gets access,
        // any other user is redirected to the login page.
        [Authorize]
        public async Task<IActionResult> Secured()
        {
            AppUser? user = await userManager.GetUserAsync(HttpContext.User);
            string message = "Hello " + user?.UserName;
            return View((object)message);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
