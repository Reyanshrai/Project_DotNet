using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Frontend.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AuthToken")))
            {
                return RedirectToAction("Login", "Auth");
            }
            
            return View();
        }

        [HttpPost]
        public IActionResult UpdateWeight(double newWeight)
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AuthToken")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // In a real application, you would call the API to update the user's weight
            TempData["SuccessMessage"] = $"Weight updated to {newWeight} kg";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult BookClass(int classId)
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AuthToken")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // In a real application, you would call the API to book the class
            TempData["SuccessMessage"] = "Class booked successfully";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult UpdateSubscription(int planId)
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AuthToken")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // In a real application, you would call the API to update the subscription
            TempData["SuccessMessage"] = "Subscription updated successfully";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public IActionResult UpdateDietPlan(int planId)
        {
            // Check if user is logged in
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AuthToken")))
            {
                return RedirectToAction("Login", "Auth");
            }

            // In a real application, you would call the API to update the diet plan
            TempData["SuccessMessage"] = "Diet plan updated successfully";
            return RedirectToAction("Dashboard");
        }
    }
} 