using BuildingCompanyMVC.Models.ViewComponents;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BuildingCompanyMVC.Controllers
{
    public class AccountController: Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName!, model.Password!, model.RememberMe, false);
            if (result.Succeeded) 
            {
                return Redirect(returnUrl?? "/");
            }
            ModelState.AddModelError(string.Empty, "Невірний логін і пароль");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl)
        {
            await _signInManager.SignOutAsync();
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }
    }
}
