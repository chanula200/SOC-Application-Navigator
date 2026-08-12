using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApplicationNavigator.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action(nameof(SignInCallback), "Account") ?? "/Home/Index";
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public async Task<IActionResult> SignInCallback(string? returnUrl = null)
        {
            // After Azure AD logs in, this callback receives the token
            var user = User;
            if (user?.Identity?.IsAuthenticated ?? false)
            {
                var redirectPath = returnUrl ?? Url.Action("Index", "Home") ?? "/Home/Index";
                return LocalRedirect(redirectPath);
            }

            return RedirectToAction("Login");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Logout()
        {
            return SignOut(
                new AuthenticationProperties { RedirectUri = Url.Action(nameof(Login), "Account") },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
