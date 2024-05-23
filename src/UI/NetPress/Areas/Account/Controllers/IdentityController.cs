using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetPress.Areas.Account.ViewModels.Identity;
using NetPress.Domain.Entities;

namespace NetPress.Areas.Account.Controllers
{
    [Area("Account")]
    public class IdentityController(ILogger<IdentityController> logger, SignInManager<User> signInManager) : Controller
    {
        [Route("account/login")]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl ?? Url.Content("~/")
            });
        }

        [HttpPost]
        [Route("account/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(string.IsNullOrWhiteSpace(model.ReturnUrl))
                model.ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    logger.LogInformation("User logged in.");
                    return LocalRedirect(model.ReturnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [Route("account/logout")]
        [HttpPost, HttpGet]
        public async Task<IActionResult> Logout(string? returnUrl = null)
        {
            await signInManager.SignOutAsync();
            logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
