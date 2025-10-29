using NutritionWebsite.Models;

namespace NutritionWebsite.data
{
    public static class IngredientAuxMethods
    {
        /// <summary>
        /// TODO, implement the convert to grams function 
        /// 
        /// Converts the given quantity to grams based on its unit.
        /// Currently assumes all units are in grams.
        /// </summary>
        private static decimal ConvertToGrams(float quantity, string unit)
        {
            // {
            //     case "kg": return (decimal)quantity * 1000;
            //     case "oz": return (decimal)quantity * 28.3495m;
            //     case "lb": return (decimal)quantity * 453.592m;
            //     default: return (decimal)quantity;
            // }

            return (decimal)quantity; // currently all in grams
        }

        /// <summary>
        /// Sums nutrients for a list of MealIngredients, taking into account the quantity of each ingredient.
        /// Assumes nutrient values are per 100g.
        /// </summary>
        public static Ingredient SumMealNutrients(IEnumerable<MealIngredients> mealIngredients)
        {


            if (mealIngredients == null || !mealIngredients.Any())
            {
                return new Ingredient
                {
                    NamePrimary = "Empty Meal",
                    NameSecondary = "",
                    Energy = 0,
                    Moisture = 0,
                    Protein = 0,
                    FatTotal = 0,
                    DietaryFibre = 0,

                    TotalSugar = 0,
                    TotalStarch = 0,
                    TotalTransFat = 0,
                    TotalSaturatedFat = 0,
                    TotalMonounsaturatedFat = 0,
                    TotalPolyunsaturatedFat = 0,

                    Calcium = 0,
                    Chloride = 0,
                    Copper = 0,
                    Iron = 0,
                    Magnesium = 0,
                    Manganese = 0,
                    Phosphorus = 0,
                    Potassium = 0,
                    Sodium = 0,
                    Sulphur = 0,
                    Zinc = 0,

                    Chromium = 0,
                    Cobalt = 0,
                    Fluoride = 0,
                    Iodine = 0,
                    Lead = 0,
                    Mercury = 0,
                    Molybdenum = 0,
                    Nickle = 0,
                    Selenium = 0,
                    Tin = 0,

                    VitaminAequivalent = 0,
                    VitaminB1 = 0,
                    VitaminB2 = 0,
                    VitaminB3 = 0,
                    NiacinEquivalents = 0,
                    VitaminB5 = 0,
                    VitaminB6 = 0,
                    VitaminB7 = 0,
                    VitaminB12 = 0,
                    VitaminC = 0,
                    VitaminE = 0,
                    Folate = 0,
                    FolicAcidEquivalents = 0
                };
            }

            var total = new Ingredient
            {
                NamePrimary = "Meal"
            };

            foreach (var mi in mealIngredients)
            {
                var ing = mi.Ingredient;
                var grams = ConvertToGrams(mi.Quantity, mi.Unit);

                // Scale nutrients proportionally (assuming ingredient data is per 100g)
                var factor = grams / 100m;

                total.Energy += (int)(ing.Energy * factor);
                total.Moisture += ing.Moisture * factor;
                total.Protein += ing.Protein * factor;
                total.FatTotal += ing.FatTotal * factor;
                total.DietaryFibre += ing.DietaryFibre * factor;

                total.TotalSugar += ing.TotalSugar * factor;
                total.TotalStarch += ing.TotalStarch * factor;
                total.TotalTransFat += ing.TotalTransFat * factor;
                total.TotalSaturatedFat += ing.TotalSaturatedFat * factor;
                total.TotalMonounsaturatedFat += ing.TotalMonounsaturatedFat * factor;
                total.TotalPolyunsaturatedFat += ing.TotalPolyunsaturatedFat * factor;

                total.Calcium += ing.Calcium * factor;
                total.Chloride += ing.Chloride * factor;
                total.Copper += ing.Copper * factor;
                total.Iron += ing.Iron * factor;
                total.Magnesium += ing.Magnesium * factor;
                total.Manganese += ing.Manganese * factor;
                total.Phosphorus += ing.Phosphorus * factor;
                total.Potassium += ing.Potassium * factor;
                total.Sodium += ing.Sodium * factor;
                total.Sulphur += ing.Sulphur * factor;
                total.Zinc += ing.Zinc * factor;

                total.Chromium += ing.Chromium * factor;
                total.Cobalt += ing.Cobalt * factor;
                total.Fluoride += ing.Fluoride * factor;
                total.Iodine += ing.Iodine * factor;
                total.Lead += ing.Lead * factor;
                total.Mercury += ing.Mercury * factor;
                total.Molybdenum += ing.Molybdenum * factor;
                total.Nickle += ing.Nickle * factor;
                total.Selenium += ing.Selenium * factor;
                total.Tin += ing.Tin * factor;

                total.VitaminAequivalent += ing.VitaminAequivalent * factor;
                total.VitaminB1 += ing.VitaminB1 * factor;
                total.VitaminB2 += ing.VitaminB2 * factor;
                total.VitaminB3 += ing.VitaminB3 * factor;
                total.NiacinEquivalents += ing.NiacinEquivalents * factor;
                total.VitaminB5 += ing.VitaminB5 * factor;
                total.VitaminB6 += ing.VitaminB6 * factor;
                total.VitaminB7 += ing.VitaminB7 * factor;
                total.VitaminB12 += ing.VitaminB12 * factor;
                total.VitaminC += ing.VitaminC * factor;
                total.VitaminE += ing.VitaminE * factor;
                total.Folate += ing.Folate * factor;
                total.FolicAcidEquivalents += ing.FolicAcidEquivalents * factor + ing.Folate * factor;
            }

            return total;
        }
    }

    }
