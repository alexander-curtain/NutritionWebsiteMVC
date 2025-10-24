using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using NutritionWebsite.data;
using NutritionWebsite.Models;

namespace NutritionWebsite.Controllers
{
    // for passing data to the view
    public class MealViewModel
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public DateTime Planned { get; set; }
    }

    [Authorize]
    public class MealPlanningController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public MealPlanningController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public async Task<IActionResult> Planning()
        {

            var currentUser = await _userManager.GetUserAsync(User);    
            if (currentUser == null)
            {
                return NotFound();
            }
            var userID = currentUser.Id;

            var usersMeals = _db.UsersMeals
                .Where(m => m.Meal.UserId == userID)
                .Select(m => new MealViewModel { Id = m.Id, MealName = m.Meal.MealName, Planned = m.Planned })
                .ToList();

            var Meals = _db.Meals
                .Where(m => m.UserId == userID)
                .ToList();

            return View((usersMeals, Meals));
        }

        [HttpPost]
        public IActionResult addPlannedMeal(int mealId, DateTime planned)
        {
            //TODO - Add server side Validation

            Meals meal = _db.Meals.Find(mealId);
            if (meal == null)
            {
                return NotFound();
            }

            UsersMeals plannedMeal = new UsersMeals { Meal = meal, MealId = mealId, Planned = planned };

            _db.UsersMeals.Add(plannedMeal);
            _db.SaveChanges();

            return RedirectToAction("Planning");
        }


        public IActionResult Graph()
        {
            return View();
        }

        public async Task<IActionResult> AddIngredients(int id)
        {
            var currentUser = await _userManager.GetUserAsync(User);

            var meal = _db.Meals.Find(id);
            if (meal == null)
                return NotFound();

            if (meal.UserId != currentUser.Id) // User Validation for meals (only the user that made the meal can edit it)
            {
                return NotFound(); 
            }

            return View(id);
        }

        [HttpPost]
        public JsonResult SearchIngredient(string search)
        {
            if (string.IsNullOrWhiteSpace(search))
                return Json(Enumerable.Empty<string>());

            var results = _db.Ingredients
                .Where(s => (s.NamePrimary).Contains(search))
                .Select(s => "[" + s.NamePrimary + s.NameSecondary + "]" )
                .Take(15)
                .ToList();

            return Json(results);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(String mealName)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            var newMeal = new Meals
            {
                MealName = mealName,
                User = currentUser,
                UserId = User.Identity.ToString(),
            };



            _db.Meals.Add(newMeal);
            _db.SaveChanges();

            return RedirectToAction("AddIngredients", new { id = newMeal.Id } );
        }


        [HttpPost]
        public IActionResult AddIngredientToMeal(string ingredientName, float quantity, string unit, int mealId)
        {
            // validation scripts
            if (ingredientName == "")
                ModelState.AddModelError("ingredientName", "Must Contain a valid ingredient");
            if (quantity <= 0)
                ModelState.AddModelError("quantity", "Quantity must be greater than 0.");
            if (false) // add a list of valid units
                ModelState.AddModelError("Unit", "Unit is required.");

            if (!ModelState.IsValid)
            {
                // Re-display the same view (still just passing the mealId)
                return View("AddIngredients", mealId);
            }
            var id = _db.Ingredients.Where(s => s.NamePrimary == ingredientName).ToList();
            if (id == null)
            {
                return NotFound();
            }

            Meals meal = _db.Meals.Find(mealId);
            if (meal == null)
            {
                return NotFound();
            }

            // for now we Dump the list and take the top of the stack, will change later with use of search.
            // TODO FIX MANY TO ONE RELATION WITH SEARCH
            int selected_id = id.FirstOrDefault().Id;

            Ingredient ingredient = _db.Ingredients.Find(selected_id); // no null check needed since this has already been selected from the table.

            var newMealIngredient = new MealIngredients
            {
                MealId = mealId,
                Meal = meal,
                Quantity = quantity,
                Unit = unit,
                Ingredient = ingredient,
                IngredientId = selected_id
            };

            _db.MealIngredients.Add(newMealIngredient);
            _db.SaveChanges();

            return RedirectToAction("AddIngredients", new { id = mealId });
        }


            public JsonResult GetMealIngredients(int mealId)
            {
                var ingredients = _db.MealIngredients   .Where(s => s.MealId == mealId)
                                                        .Select(mi => mi.Ingredient.NamePrimary + "$" + mi.Ingredient.NameSecondary + "$" + mi.Quantity + mi.Unit )
                                                        .ToList();

                // select from Ingredients Names of Ingredients

                if (ingredients.Count != 0)
                {
                    return Json(ingredients);
                } else
                {
                    return Json("");
                }
            
            }

        // finalisation/cancellation of meal
        public IActionResult FinaliseMeal()
        {
            return RedirectToAction("Planning");
        }
        public IActionResult CancelMeal(int id)
        {

            Meals meal = _db.Meals.Find(id);
            if (meal == null)
            {
                return NotFound();
            }

            var mealIngredients = _db.MealIngredients.Where(m => m.MealId == id);

            _db.MealIngredients.RemoveRange(mealIngredients);

            _db.Meals.Remove(meal);

            _db.SaveChanges();

            return RedirectToAction("Planning");
        }



    }    
}
