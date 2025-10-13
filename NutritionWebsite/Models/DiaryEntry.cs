using System.ComponentModel.DataAnnotations;

namespace NutritionWebsite.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Must Enter A Title!")]
        [StringLength(64, ErrorMessage = "Title Cannot Be Longer than 64 characters!")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
         
    }
}
