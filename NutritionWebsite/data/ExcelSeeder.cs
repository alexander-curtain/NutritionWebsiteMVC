using ExcelDataReader;
using NutritionWebsite.Models;
using System.Globalization;

namespace NutritionWebsite.Data
{
    public static class ExcelSeeder
    {
        public static List<Ingredient> LoadIngredientsFromExcel(string filePath)
        {
            var ingredients = new List<Ingredient>();

            using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
            using var reader = ExcelReaderFactory.CreateReader(stream);
            var dataSet = reader.AsDataSet();

            // Food groups (per 100g)
            var table = dataSet.Tables[1];

            // Skip the header (row 0)
            for (int i = 1; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i];

                try
                {
                    int positionOfFirstComma = (row[2].ToString() ?? "").IndexOf(','); // used for splitting the "name" of an ingredient from secondary qualities
                    if (positionOfFirstComma == -1) { positionOfFirstComma = (row[3].ToString() ?? "").Length; }
                    string name = (row[2].ToString() ?? "").Substring(0, positionOfFirstComma);
                    string subName = (row[2].ToString() ?? "").Substring(positionOfFirstComma);


                    var ingredient = new Ingredient
                    {
                        // Name 
                        NamePrimary = name,
                        NameSecondary = subName,

                        // Overview
                        Energy = ParseInt(row[4]),
                        Moisture = ParseDecimal(row[5]),
                        Protein = ParseDecimal(row[6]),
                        FatTotal = ParseDecimal(row[8]),
                        DietaryFibre = ParseDecimal(row[10]),

                        //Breakdown
                        TotalSugar = ParseDecimal(row[19]),
                        TotalStarch = ParseDecimal(row[22]),
                        TotalTransFat = ParseDecimal(row[254]) / 1000,
                        TotalSaturatedFat = ParseDecimal(row[202]),
                        TotalMonounsaturatedFat = ParseDecimal(row[225]),
                        TotalPolyunsaturatedFat = ParseDecimal(row[251]),

                        // Minerals
                        Calcium = ParseDecimal(row[55]),
                        Chloride = ParseDecimal(row[57]),
                        Copper = ParseDecimal(row[59]),
                        Iron = ParseDecimal(row[62]),
                        Magnesium = ParseDecimal(row[64]),
                        Manganese = ParseDecimal(row[65]),
                        Phosphorus = ParseDecimal(row[69]),
                        Potassium = ParseDecimal(row[70]),
                        Sodium = ParseDecimal(row[72]),
                        Sulphur = ParseDecimal(row[73]),
                        Zinc = ParseDecimal(row[75]),

                        Chromium = ParseDecimal(row[56]),
                        Cobalt = ParseDecimal(row[58]),
                        Fluoride = ParseDecimal(row[60]),
                        Iodine = ParseDecimal(row[61]),
                        Lead = ParseDecimal(row[63]),
                        Mercury = ParseDecimal(row[66]),
                        Molybdenum = ParseDecimal(row[67]),
                        Nickle = ParseDecimal(row[68]),
                        Selenium = ParseDecimal(row[71]),
                        Tin = ParseDecimal(row[74]),

                        // Vitamins
                        VitaminAequivalent = ParseDecimal(row[81]),
                        VitaminB1 = ParseDecimal(row[86]),
                        VitaminB2 = ParseDecimal(row[87]),
                        VitaminB3 = ParseDecimal(row[88]),
                        NiacinEquivalents = ParseDecimal(row[89]),
                        VitaminB5 = ParseDecimal(row[90]),
                        VitaminB6 = ParseDecimal(row[91]),
                        VitaminB7 = ParseDecimal(row[92]),
                        VitaminB12 = ParseDecimal(row[93]),
                        VitaminC = ParseDecimal(row[101]),
                        VitaminE = ParseDecimal(row[110])
                    };


                    ingredients.Add(ingredient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing row {i}: {ex.Message}");
                }
            }

            return ingredients;
        }

        private static int ParseInt(object? value)
        {
            if (value == null) return 0;
            int.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out int result);
            return result;
        }

        private static decimal ParseDecimal(object? value)
        {
            if (value == null) return 0;
            decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result);
            return result;
        }

    }
}
