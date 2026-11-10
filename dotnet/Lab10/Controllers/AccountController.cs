using Lab10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab10.Controllers
{
    // Only authenticated users reach the actions of this controller by default;
    // Register/Login are opened up again with [AllowAnonymous] (Unit 8 slide 32).
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(UserManager<AppUser> userMgr, SignInManager<AppUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        // Registration ---------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register() => View();

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = register.UserName,
                    Email = register.Email
                };

                IdentityResult result = await userManager.CreateAsync(appUser, register.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");

                foreach (IdentityError error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(register);
        }

        // Login ----------------------------------------------------------
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            Login login = new Login { ReturnUrl = returnUrl };
            return View(login);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                AppUser? appUser = await userManager.FindByEmailAsync(login.Email);

                if (appUser != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(appUser, login.Password, false, false);

                    if (result.Succeeded)
                    {
                        // Redirect to the return URL only when it is a local URL (prevents open redirect attacks).
                        if (Url.IsLocalUrl(login.ReturnUrl))
                            return Redirect(login.ReturnUrl!);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.AddModelError("", "Login Failed: Invalid Email or password");
            }
            return View(login);
        }

        // Logout ---------------------------------------------------------
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}