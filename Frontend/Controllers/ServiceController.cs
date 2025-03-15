using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;

namespace Frontend.Controllers;

public class ServiceController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public ServiceController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
}

