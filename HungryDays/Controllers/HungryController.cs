using System.Diagnostics;
using HungryDays.Models;
using HungryDays.Services;
using Microsoft.AspNetCore.Mvc;

namespace HungryDays.Controllers
{
    public class HungryController : Controller
    {
        private readonly ILogger<HungryController> _logger;
        private readonly HungryRepository _hungryService;
        public HungryController(ILogger<HungryController> logger, HungryRepository hungryService)
        {
            _logger = logger;
            _hungryService = hungryService;
        }

        public IActionResult Index()
        {
            var hungryDays = _hungryService.GetAllHungryDays();
            return View(hungryDays);
        }

        public IActionResult Detail(int id)
        {
            var hungryDay = _hungryService.GetHungryDay(id);
            return View(hungryDay);
        }

        public IActionResult Edit(int id)
        {
            var hungryDay = _hungryService.GetHungryDay(id);
            return View(hungryDay);
        }

        //public IActionResult Edit(HungryDay hungryDay)
        //{
        //    var hungryDay = _hungryService;
        //    return View(hungryDay);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}