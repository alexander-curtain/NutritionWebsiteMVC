using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionWebsite.Models
{
    public class Meals
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        // Navigation property
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
        public string MealName { get; set; } = string.Empty;

        // Navigation property
        public ICollection<MealIngredients> Ingredients { get; set; } = new List<MealIngredients>();

    }
}
