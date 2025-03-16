using System.Collections.Generic;

namespace Frontend.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public required string ImageSrc { get; set; }
        public required string Heading { get; set; }
        public required string Subheading { get; set; }
        public required string Duration { get; set; }
        public required string Trainer { get; set; }
        public required string Intensity { get; set; }

        public static List<ServiceViewModel> GetServices()
        {
            return new List<ServiceViewModel>
            {
                new ServiceViewModel { Id = 1, ImageSrc = "/images/slide1.jpg", Heading = "Weight Loss", Subheading = "Weight Loss Session", Duration = "60 mins", Trainer = "Expert Trainers", Intensity = "Medium to High" },
                new ServiceViewModel { Id = 2, ImageSrc = "/images/slide2.jpg", Heading = "Yoga", Subheading = "Yoga Session", Duration = "45 mins", Trainer = "Certified Instructors", Intensity = "Low to Medium" },
                new ServiceViewModel { Id = 3, ImageSrc = "/images/slide3.jpg", Heading = "Energy Blast", Subheading = "Energy Blast Session", Duration = "30 mins", Trainer = "Professional Coaches", Intensity = "High" },
                new ServiceViewModel { Id = 4, ImageSrc = "/images/service1.png", Heading = "Cardio", Subheading = "Cardio Session", Duration = "45 mins", Trainer = "Fitness Experts", Intensity = "Medium to High" },
                new ServiceViewModel { Id = 5, ImageSrc = "/images/service2.png", Heading = "Strength", Subheading = "Strength Training", Duration = "60 mins", Trainer = "Professional Trainers", Intensity = "High" },
                new ServiceViewModel { Id = 6, ImageSrc = "/images/aboutimg1.png", Heading = "Pilates", Subheading = "Pilates Session", Duration = "45 mins", Trainer = "Certified Instructors", Intensity = "Low to Medium" }
            };
        }
    }
}
