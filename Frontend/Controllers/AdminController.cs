using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApiService _apiService;

        public AdminController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _apiService.LoginAdmin(model);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);

                if (response != null && response.Success)
                {
                    // Store token in session or cookie
                    if (response.Token != null)
                    {
                        HttpContext.Session.SetString("AdminAuthToken", response.Token);
                    }
                    
                    if (response.User != null && response.User.FirstName != null && response.User.LastName != null)
                    {
                        HttpContext.Session.SetString("AdminName", $"{response.User.FirstName} {response.User.LastName}");
                    }
                    else
                    {
                        HttpContext.Session.SetString("AdminName", "Administrator");
                    }
                    
                    HttpContext.Session.SetString("IsAdmin", "true");
                    
                    return RedirectToAction("Dashboard");
                }
                
                // Add error message to the view
                ViewData["ErrorMessage"] = response?.Error ?? "Admin login failed";
                return View(model);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = $"Login failed: {ex.Message}";
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Check if admin is logged in
            if (HttpContext.Session.GetString("IsAdmin") != "true")
            {
                return RedirectToAction("Login");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Logout()
        {
            // Clear session
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
} 