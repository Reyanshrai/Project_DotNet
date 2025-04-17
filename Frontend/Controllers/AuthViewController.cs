using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using Newtonsoft.Json;

namespace Frontend.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApiService _apiService;

        public AuthController(ApiService apiService)
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
                var result = await _apiService.LoginUser(model);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);

                if (response != null && response.Success)
                {
                    // Store token in session or cookie
                    if (response.Token != null)
                    {
                        HttpContext.Session.SetString("AuthToken", response.Token);
                    }
                    
                    if (response.User != null && response.User.FirstName != null && response.User.LastName != null)
                    {
                        HttpContext.Session.SetString("UserName", $"{response.User.FirstName} {response.User.LastName}");
                    }
                    
                    // Redirect to User Dashboard instead of Home
                    return RedirectToAction("Dashboard", "User");
                }
                
                ModelState.AddModelError("", response?.Message ?? response?.Error ?? "Login failed");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Login failed: {ex.Message}");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var result = await _apiService.RegisterUser(model);
                var response = JsonConvert.DeserializeObject<AuthResponse>(result);

                if (response != null && response.Success)
                {
                    TempData["SuccessMessage"] = "Registration successful! Please login.";
                    return RedirectToAction("Login");
                }
                
                ModelState.AddModelError("", response?.Message ?? response?.Error ?? "Registration failed");
                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Registration failed: {ex.Message}");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "Email is required");
                return View();
            }
            
            // In a real application, you would call the API to send a password reset email
            // For now, we'll just show a success message
            TempData["Message"] = "Password reset instructions have been sent to your email.";
            return RedirectToAction("Login");
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