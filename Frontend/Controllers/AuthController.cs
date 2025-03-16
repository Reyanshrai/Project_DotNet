using Frontend.Models;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;

namespace YourNamespace.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Mobile = string.Empty,
                Gender = string.Empty,
                Password = string.Empty,
                RepeatPassword = string.Empty
            });
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // TODO: Save user to database (Add logic here)
            TempData["SuccessMessage"] = "Registration successful! Please log in.";
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
