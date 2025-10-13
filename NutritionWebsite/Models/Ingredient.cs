using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace NutritionWebsite.Models
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        // Classificiations
        [Required]
        public string NamePrimary { get; set; } = "";
        public string? NameSecondary { get; set; }

        // Caloric Weights
        [Required]
        public int Energy { get; set; } = 0;
        [Required] 

        public Decimal Moisture { get; set; } = 0;
        [Required] 
        public Decimal Protein { get; set; } = 0;
        [Required] 
        public Decimal FatTotal { get; set; } = 0;
        [Required] 
        public Decimal DietaryFibre { get; set; } = 0;


        // breakdown of caloric makeup  
        public Decimal TotalSugar { get; set; }
        public Decimal TotalStarch { get; set; }
        public Decimal TotalTransFat { get; set; }
        public Decimal TotalSaturatedFat { get; set; }
        public Decimal TotalMonounsaturatedFat { get; set; }
        public Decimal TotalPolyunsaturatedFat { get; set; }
        

        // minerals milligrams
        public Decimal Calcium { get; set; }
        public Decimal Chloride { get; set; }
        public Decimal Copper { get; set; }
        public Decimal Iron { get; set; }
        public Decimal Magnesium { get; set; }
        public Decimal Manganese { get; set; }
        public Decimal Phosphorus { get; set; }
        public Decimal Potassium { get; set; }
        public Decimal Sodium { get; set; }
        public Decimal Sulphur { get; set; }
        public Decimal Zinc { get; set; }

        // minerals micrograms
        public Decimal Chromium { get; set; }
        public Decimal Cobalt  { get; set; }
        public Decimal Fluoride  { get; set; }
        public Decimal Iodine  { get; set; }
        public Decimal Lead  { get; set; }
        public Decimal Mercury  { get; set; }
        public Decimal Molybdenum  { get; set; }
        public Decimal Nickle  { get; set; }
        public Decimal Selenium  { get; set; }
        public Decimal Tin  { get; set; }

        //Vitamins
        public Decimal VitaminAequivalent { get; set; }
        public Decimal VitaminB1 { get; set; }
        public Decimal VitaminB2 { get; set; }
        public Decimal VitaminB3 { get; set; }
        public Decimal NiacinEquivalents { get; set; }
        public Decimal VitaminB5 { get; set; }
        public Decimal VitaminB6 { get; set; }
        public Decimal VitaminB7  { get; set; }
        public Decimal VitaminB12  { get; set; }
        public Decimal VitaminC { get; set; }
        public Decimal VitaminE { get; set; }


        public Decimal Folate  { get; set; }
        public Decimal FolicAcidEquivalents  { get; set; }




    }
}
