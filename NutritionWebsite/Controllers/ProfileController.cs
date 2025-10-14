using Microsoft.AspNetCore.Mvc;

namespace NutritionWebsite.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
