using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using System.Collections.Generic;

namespace Frontend.Controllers
{
    public class TimetableController : Controller
    {
        public IActionResult Index()
        {
            var timetable = new List<TimetableViewModel>
            {
                new() { Day = "Sunday", Sessions = new List<string> { "Weight Loss\n10 am - 11 am\nWayne Ponce", "", "Yoga\n03 pm - 04 pm\nFrancisco Watt", "Boxing\n05 pm - 06 pm\nCharles King", "" } },
                new() { Day = "Monday", Sessions = new List<string> { "", "Cycling\n11 am - 12 pm\nTabitha Porter", "Karate\n03 pm - 05 pm\nLester Gray", "", "Crossfit\n07 pm - 08 pm\nCandi Vip" } },
                new() { Day = "Tuesday", Sessions = new List<string> { "Spinning\n10 am - 11 am\nMary Cass", "", "Dance\n03 pm - 05 pm\nBrian Ashworth", "", "Boxercise\n07 pm - 08 pm\nMarlene Bruce" } },
                new() { Day = "Wednesday", Sessions = new List<string> { "Body Building\n10 am - 12 pm\nBrenda Hester", "", "", "Bootcamp\n05 pm - 06 pm\nBrenda Mastrodicasio", "Health\n07 pm - 08 pm\nMark Croteau" } },
                new() { Day = "Thursday", Sessions = new List<string> { "", "Bootcamp\n11 am - 12 pm\nElisabeth Schreck", "", "Body Building\n05 pm - 06 pm\nEdward Garcia", "" } },
                new() { Day = "Friday", Sessions = new List<string> { "Racing\n10 am - 11 am\nJackie Potts", "", "Energy Blast\n03 pm - 05 pm\nTravis Brown", "", "Jumping\n07 pm - 08 pm\nBenjamin Barnett" } },
                new() { Day = "Saturday", Sessions = new List<string> { "", "", "Aerobics\n03 pm - 04 pm\nAndre Walls", "Cycling\n05 pm - 06 pm\nMargaret Thomas", "" } }
            };

            return View(timetable);
        }
    }
}
