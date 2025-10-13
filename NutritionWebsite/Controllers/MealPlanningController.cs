using Microsoft.AspNetCore.Mvc;

namespace NutritionWebsite.Controllers
{
    public class MealPlanningController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
