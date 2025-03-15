using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            var services = new List<ServiceViewModel>
            {
                new() { Id = 1, ImageUrl = "/images/slide1.jpg", Heading = "Weight Loss", Subheading = "Weight Loss Session", Duration = "60 mins", Trainer = "Expert Trainers", Intensity = "Medium to High" },
                new() { Id = 2, ImageUrl = "/images/slide2.jpg", Heading = "Yoga", Subheading = "Yoga Session", Duration = "45 mins", Trainer = "Certified Instructors", Intensity = "Low to Medium" },
                new() { Id = 3, ImageUrl = "/images/slide3.jpg", Heading = "Energy Blast", Subheading = "Energy Blast Session", Duration = "30 mins", Trainer = "Professional Coaches", Intensity = "High" },
                new() { Id = 4, ImageUrl = "/images/service1.png", Heading = "Cardio", Subheading = "Cardio Session", Duration = "45 mins", Trainer = "Fitness Experts", Intensity = "Medium to High" },
                new() { Id = 5, ImageUrl = "/images/service2.png", Heading = "Strength", Subheading = "Strength Training", Duration = "60 mins", Trainer = "Professional Trainers", Intensity = "High" },
                new() { Id = 6, ImageUrl = "/images/aboutimg1.png", Heading = "Pilates", Subheading = "Pilates Session", Duration = "45 mins", Trainer = "Certified Instructors", Intensity = "Low to Medium" }
            };

            return View(services);
        }
    }
}
