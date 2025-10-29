using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using NutritionWebsite.data;
using NutritionWebsite.Models;
using System.Data.Entity;

namespace NutritionWebsite.Controllers
{
    public class GraphingController : Controller
    {
        private readonly ApplicationDbContext _db;
        private List<(int, string, char)> idNameType;

        public GraphingController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SingleItem(int? id, char? type)
        {
            Ingredient dailyIntake = _db.Ingredients.Where(m => m.NamePrimary == "Daily Recommened Intake").FirstOrDefault();
            if (dailyIntake == null)
            {
                return NotFound(); // TODO - add better error message here to capture the daily recommended intake is missing.
            }
            // TODO Implement Meal (which requires summing up a bunch of stuff and creating a fake ingredient ERK)
            Ingredient item = null;
            if (id != null)
            {
                if (type == 'I')
                {
                    item = _db.Ingredients.FirstOrDefault(m => m.Id == id); // if null, no problem occurs, just returns default condition as if it didn't search anything
                    item.NamePrimary += "/100g";
                }
                if (type == 'M')
                {
                    var Ingredients = _db.MealIngredients.Where(m => m.MealId == id).Include(m => m.Ingredient).ToList(); // gets first item.

                    foreach (var m in Ingredients) {
                        m.Ingredient = _db.Ingredients.FirstOrDefault(s => s.Id == m.IngredientId);
                    }

                    item = IngredientAuxMethods.SumMealNutrients(Ingredients); // sums all the nutrients in the meal
                }

            } 

            return View((item, dailyIntake)); // TODO return Ingredient and daily intake.
        }


        [HttpPost]
        public IActionResult Search(string search, char type)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Json(new List<object>());

            var results = (type == 'I')
                ? _db.Ingredients
                    .Where(s => s.NamePrimary.Contains(search))
                    .Select(s => new { id = s.Id, name = s.NamePrimary + s.NameSecondary, type = "I" })
                    .OrderBy(s => !s.name.StartsWith(search))  // true (non-match) comes after false (match)
                    .ThenBy(s => s.name.IndexOf(search))       // earlier matches rank higher
                    .ThenBy(s => s.name)                   // tie-break alphabetically
                    .Take(15)
                    .ToList<object>()
                : _db.Meals
                    .Where(s => s.MealName.Contains(search))
                    .Select(s => new { id = s.Id, name = s.MealName, type = "M" })
                    .Take(15)
                    .ToList<object>();

            return Json(results);
        }


    }
}
