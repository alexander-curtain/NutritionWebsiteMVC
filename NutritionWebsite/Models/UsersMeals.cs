using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionWebsite.Models
{
    // represents the which meals they are having at each time
    public class UsersMeals
    {
        public int Id { get; set; }
        
        public int MealId { get; set; }
        [ForeignKey("Meals")]
        public Meals Meal { get; set; }
        public DateTime Planned { get; set; }
    }
}
