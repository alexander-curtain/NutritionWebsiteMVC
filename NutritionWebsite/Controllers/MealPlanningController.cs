using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NutritionWebsite.Controllers
{
    public class MealPlanningController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
