using System.ComponentModel.DataAnnotations;

namespace NutritionWebsite.Models
{
    public class UnitsConversion
    {
        public int Id {  get; set; }
        [Required]
        public string Nutrient { get; set; }
        [Required]
        public string Unit { get; set; }
    }
}
