using System.ComponentModel.DataAnnotations;

namespace NutritionWebsite.Models
{
    public class UnitsConversion
    {
        public int Id { get; set; }
        [Required]
        public string Nutrient { get; set; } = string.Empty;
        [Required]
        public string Unit { get; set; } = string.Empty;
    }
}

