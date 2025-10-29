using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NutritionWebsite.data;
using NutritionWebsite.Models;

namespace NutritionWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            Ingredient dailyIntake = _db.Ingredients.Where(m => m.NamePrimary == "Daily Recommened Intake").FirstOrDefault();
            if (dailyIntake == null)
            {
                return NotFound(); // TODO - add better error message here to capture the daily recommended intake is missing.
            }
            return View(dailyIntake);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MyPage()
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
