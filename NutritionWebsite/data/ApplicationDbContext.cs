using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NutritionWebsite.Data;
using NutritionWebsite.Models;

namespace NutritionWebsite.data
{
    public class ApplicationDbContext : IdentityDbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
                    
         }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Meals> Meals { get; set; }
        public DbSet<MealIngredients> MealIngredients { get; set; }
        public DbSet<UsersMeals> UsersMeals { get; set; }
    


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Meals>()
                .HasMany(m => m.Ingredients)
                .WithOne(i => i.Meal)
                .HasForeignKey(i => i.MealId)
                .OnDelete(DeleteBehavior.Cascade); // optional: removes ingredients when meal is deleted

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Id = 1, Title = "Went Hiking", Description = "hated it", Created = new DateTime(2025, 10, 3) },
                new DiaryEntry { Id = 2, Title = "On a hate binge", Description = "filled with hatred", Created = new DateTime(2025, 10, 4) },
                new DiaryEntry { Id = 3, Title = "On a love binge", Description = "wow today was nice", Created = new DateTime(2025, 10, 5) }
                );


            
            modelBuilder.Entity<UnitsConversion>().HasData(
                // Kilo Joules
                new UnitsConversion { Id = 1, Nutrient = "Energy", Unit = "KiloJoules" },

                // Grams
                new UnitsConversion { Id = 2, Nutrient = "Moisture", Unit = "Grams" },
                new UnitsConversion { Id = 3, Nutrient = "Protein", Unit = "Grams" },
                new UnitsConversion { Id = 4, Nutrient = "Fat", Unit = "Grams" },
                new UnitsConversion { Id = 5, Nutrient = "DietryFibre", Unit = "Grams" },

                // Milligrams
                new UnitsConversion { Id = 6, Nutrient = "Calcium", Unit = "Milligrams" },
                new UnitsConversion { Id = 7, Nutrient = "Chloride", Unit = "Milligrams" },
                new UnitsConversion { Id = 8, Nutrient = "Copper", Unit = "Milligrams" },
                new UnitsConversion { Id = 9, Nutrient = "Iron", Unit = "Milligrams" },
                new UnitsConversion { Id = 10, Nutrient = "Magnesium", Unit = "Milligrams" },
                new UnitsConversion { Id = 11, Nutrient = "Manganese", Unit = "Milligrams" },
                new UnitsConversion { Id = 12, Nutrient = "Phosphorus", Unit = "Milligrams" },
                new UnitsConversion { Id = 13, Nutrient = "Potassium", Unit = "Milligrams" },
                new UnitsConversion { Id = 14, Nutrient = "Sodium", Unit = "Milligrams" },
                new UnitsConversion { Id = 15, Nutrient = "Sulphur", Unit = "Milligrams" },
                new UnitsConversion { Id = 16, Nutrient = "Zinc", Unit = "Milligrams" },
                new UnitsConversion { Id = 17, Nutrient = "VitaminB1", Unit = "Milligrams" },
                new UnitsConversion { Id = 18, Nutrient = "VitaminB2", Unit = "Milligrams" },
                new UnitsConversion { Id = 19, Nutrient = "VitaminB3", Unit = "Milligrams" },
                new UnitsConversion { Id = 20, Nutrient = "NiacinEquivalents", Unit = "Milligrams" },
                new UnitsConversion { Id = 21, Nutrient = "VitaminB5", Unit = "Milligrams" },
                new UnitsConversion { Id = 22, Nutrient = "VitaminB6", Unit = "Milligrams" },
                new UnitsConversion { Id = 23, Nutrient = "VitaminC", Unit = "Milligrams" },
                new UnitsConversion { Id = 24, Nutrient = "VitaminE", Unit = "Milligrams" },

                // Micrograms
                new UnitsConversion { Id = 25, Nutrient = "ChromiumMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 26, Nutrient = "CobaltMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 27, Nutrient = "FluorideMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 28, Nutrient = "IodineMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 29, Nutrient = "LeadMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 30, Nutrient = "MercuryMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 31, Nutrient = "MolybdenumMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 32, Nutrient = "NickleMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 33, Nutrient = "SeleniumMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 34, Nutrient = "TinMicrograms", Unit = "Micrograms" },
                new UnitsConversion { Id = 35, Nutrient = "VitaminAequivalent", Unit = "Micrograms" },
                new UnitsConversion { Id = 36, Nutrient = "VitaminB7", Unit = "Micrograms" },
                new UnitsConversion { Id = 37, Nutrient = "VitaminB12", Unit = "Micrograms" },
                new UnitsConversion { Id = 38, Nutrient = "Folate", Unit = "Micrograms" },
                new UnitsConversion { Id = 39, Nutrient = "FolicAcidEquivalents", Unit = "Micrograms" }
                );
        
        }

        public void SeedFromExcel(string filePath)
        {
            // Comment this out to reinject all the ingredients from excel
            if (Ingredients.Any()) return; // Avoid duplicates

            var data = ExcelSeeder.LoadIngredientsFromExcel(filePath);
            Ingredients.AddRange(data);
            SaveChanges();
        }
    }
}



