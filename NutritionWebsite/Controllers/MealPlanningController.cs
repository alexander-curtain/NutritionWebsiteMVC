using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NutritionWebsite.data;
using NutritionWebsite.Models;

namespace NutritionWebsite.Controllers
{
    [Authorize]
    public class MealPlanningController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MealPlanningController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Planning()
        {
            var currentUser = User.Identity.Name;
            List<Meals> entries = _db.Meals
                             .Where(m => m.UserId == currentUser)
                             .ToList();


            return View(entries);
        }
        public IActionResult Graph()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        public IActionResult AddIngredientToMeal(string ingredientName, float quantity, string unit)
        {
            Ingredient ingredient = _db.Ingredients.Find(ingredientName);
            if (ingredient == null)
            {
                return NotFound();
            }


            return RedirectToAction("Create");
        }
    }
}
