using System.Diagnostics;
using HungryDays.Models;
using HungryDays.Services;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HungryRepository _hungryService;
        public HomeController(ILogger<HomeController> logger, HungryRepository hungryService)
        {
            _logger = logger;
            _hungryService = hungryService;
        }

        public IActionResult Index()
        {
            var hungryDays = _hungryService.GetAllHungryDays();
            return View(hungryDays);
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