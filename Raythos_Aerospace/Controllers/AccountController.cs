using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace Raythos_Aerospace.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Logout()
        {
            // Add your logout logic here
            // For example, sign out the user and redirect to the home page
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
