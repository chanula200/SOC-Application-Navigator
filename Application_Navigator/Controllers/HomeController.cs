using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ApplicationNavigator.Models;
using ApplicationNavigator.Services;

namespace ApplicationNavigator.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly NavigationService _navigationService;

        public HomeController(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IActionResult Index()
        {
            var navigationItems = _navigationService.GetNavigationItems();
            return View(navigationItems);
        }

        [HttpPost]
        public IActionResult Navigate(string systemName, string url)
        {
            _navigationService.LogNavigation(systemName, url);
            
            return Json(new 
            { 
                success = true, 
                message = $"Navigating to {systemName}",
                url = url
            });
        }
    }
}
