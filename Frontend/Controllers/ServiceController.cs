using Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Frontend.Controllers
{
    public class ServiceController : Controller
    {
        public ActionResult Index()
        {
            List<ServiceViewModel> services = ServiceViewModel.GetServices();
            return View(services);
        }
    }
}
