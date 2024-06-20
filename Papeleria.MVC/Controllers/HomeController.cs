using Papeleria.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Papeleria.MVC.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _httpClient;
        private readonly ILogger<HomeController> _logger;

        public HomeController(HttpClient httpClient, ILogger<HomeController> logger)
        {
            _httpClient = httpClient;
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
