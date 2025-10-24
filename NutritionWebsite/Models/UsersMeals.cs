using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionWebsite.Models
{
    // represents the which meals they are having at each time
    public class UsersMeals
    {
        public int Id { get; set; }

        public int MealId { get; set; }

        [ForeignKey("MealId")]
        public required Meals Meal { get; set; } // navigation property (gets access to user)
        public DateTime Planned { get; set; }
    }
}
