using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Collections.Generic;

namespace YourProjectNamespace.Controllers
{
    public class PricingController : Controller
    {
        public ActionResult Index()
        {
            var pricingPlans = new List<PricingViewModel>
            {
                new PricingViewModel
                {
                    PlanName = "Standard Plan",
                    Price = "29",
                    Duration = "/month",
                    Features = new List<string>
                    {
                        "Unlimited access to the GYM",
                        "FREE drinking package",
                        "One year membership",
                        "3 classes per week",
                        "1 Free personal training"
                    },
                    ImageUrl = "/images/plan.png"
                },
                new PricingViewModel
                {
                    PlanName = "Premium Plan",
                    Price = "49",
                    Duration = "/month",
                    Features = new List<string>
                    {
                        "Unlimited access to the GYM",
                        "FREE drinking package",
                        "One year membership",
                        "5 classes per week",
                        "2 Free personal training"
                    },
                    ImageUrl = "/images/plan.png"
                },
                new PricingViewModel
                {
                    PlanName = "Platinum Plan",
                    Price = "99",
                    Duration = "/month",
                    Features = new List<string>
                    {
                        "Unlimited access to the GYM",
                        "FREE drinking package",
                        "Two year membership",
                        "7 classes per week",
                        "5 Free personal training"
                    },
                    ImageUrl = "/images/plan.png"
                }
            };

            return View(pricingPlans);
        }
    }
}
