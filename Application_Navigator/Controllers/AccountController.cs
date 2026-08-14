using Microsoft.AspNetCore.Mvc;

namespace ApplicationNavigator.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied() => RedirectToAction("Index", "Home");
    }
}
