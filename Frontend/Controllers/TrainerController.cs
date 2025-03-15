using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    public class TrainerController : Controller
    {
        public IActionResult Index()
        {
            var trainers = new List<TrainerViewModel>
            {
                new() {
                    Image = "/images/service1.png",
                    Title = "Himanshu Kumar",
                    Caption = "Expert Fitness Trainer",
                    Specialties = new List<string> { "Weight Training", "HIIT", "Nutrition" },
                    Experience = "8+ years",
                    Rating = 4.9,
                    SocialLinks = new Dictionary<string, string>
                    {
                        { "LinkedIn", "https://www.linkedin.com/in/himanshu" },
                        { "Instagram", "https://www.instagram.com/himanshu" },
                        { "Facebook", "https://www.facebook.com/himanshu" }
                    },
                    Description = "Himanshu is a passionate fitness trainer with extensive experience in weight training, HIIT, and nutrition."
                },
                new() {
                    Image = "/images/service2.png",
                    Title = "Raghuveer Kumar",
                    Caption = "Certified Yoga Instructor",
                    Specialties = new List<string> { "Hatha Yoga", "Meditation", "Breathing" },
                    Experience = "10+ years",
                    Rating = 4.8,
                    SocialLinks = new Dictionary<string, string>
                    {
                        { "LinkedIn", "https://www.linkedin.com/in/raghuveer" },
                        { "Instagram", "https://www.instagram.com/raghuveer" },
                        { "Facebook", "https://www.facebook.com/raghuveer" }
                    },
                    Description = "Raghuveer is a certified yoga instructor who specializes in Hatha Yoga and meditation."
                },
                new() {
                    Image = "/images/service1.png",
                    Title = "Vivek Sah",
                    Caption = "Professional Strength Coach",
                    Specialties = new List<string> { "Powerlifting", "CrossFit", "Mobility" },
                    Experience = "6+ years",
                    Rating = 4.7,
                    SocialLinks = new Dictionary<string, string>
                    {
                        { "LinkedIn", "https://www.linkedin.com/in/vivek" },
                        { "Instagram", "https://www.instagram.com/vivek" },
                        { "Facebook", "https://www.facebook.com/vivek" }
                    },
                    Description = "Vivek is a professional strength coach who focuses on powerlifting and CrossFit."
                }
            };

            return View(trainers);
        }
    }
}
