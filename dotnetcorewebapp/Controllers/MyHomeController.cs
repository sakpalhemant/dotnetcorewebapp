using System.Diagnostics;
using dotnetcorewebapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetcorewebapp.Controllers
{
    public class MyHomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MyHomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
