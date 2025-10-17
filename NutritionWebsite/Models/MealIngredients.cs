using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NutritionWebsite.Models
{
    public class MealIngredients
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int MealId { get; set; }

        [ForeignKey("MealId")]
        public required Meals Meal { get; set; } // navigation property

        public int IngredientId { get; set; }

        [ForeignKey("IngredientId")]
        public required Ingredient Ingredient { get; set; } // navigation property

        public string MealName { get; set; } = string.Empty;
        public float Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;

    }
}
