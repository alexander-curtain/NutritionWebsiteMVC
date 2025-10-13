using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NutritionWebsite.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePrimary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSecondary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Energy = table.Column<int>(type: "int", nullable: false),
                    Moisture = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Protein = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FatTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DietaryFibre = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSugar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalStarch = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalTransFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalSaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalMonounsaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPolyunsaturatedFat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Calcium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Chloride = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Copper = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iron = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Magnesium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Manganese = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Phosphorus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Potassium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sodium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sulphur = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Zinc = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Chromium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cobalt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Fluoride = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Iodine = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Lead = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mercury = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Molybdenum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Nickle = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Selenium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tin = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminAequivalent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB1 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NiacinEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB5 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB6 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB7 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminB12 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VitaminE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Folate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FolicAcidEquivalents = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitsConversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nutrient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitsConversion", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Created", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 10, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "hated it", "Went Hiking" },
                    { 2, new DateTime(2025, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "filled with hatred", "On a hate binge" },
                    { 3, new DateTime(2025, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "wow today was nice", "On a love binge" }
                });

            migrationBuilder.InsertData(
                table: "UnitsConversion",
                columns: new[] { "Id", "Nutrient", "Unit" },
                values: new object[,]
                {
                    { 1, "Energy", "KiloJoules" },
                    { 2, "Moisture", "Grams" },
                    { 3, "Protein", "Grams" },
                    { 4, "Fat", "Grams" },
                    { 5, "DietryFibre", "Grams" },
                    { 6, "Calcium", "Milligrams" },
                    { 7, "Chloride", "Milligrams" },
                    { 8, "Copper", "Milligrams" },
                    { 9, "Iron", "Milligrams" },
                    { 10, "Magnesium", "Milligrams" },
                    { 11, "Manganese", "Milligrams" },
                    { 12, "Phosphorus", "Milligrams" },
                    { 13, "Potassium", "Milligrams" },
                    { 14, "Sodium", "Milligrams" },
                    { 15, "Sulphur", "Milligrams" },
                    { 16, "Zinc", "Milligrams" },
                    { 17, "VitaminB1", "Milligrams" },
                    { 18, "VitaminB2", "Milligrams" },
                    { 19, "VitaminB3", "Milligrams" },
                    { 20, "NiacinEquivalents", "Milligrams" },
                    { 21, "VitaminB5", "Milligrams" },
                    { 22, "VitaminB6", "Milligrams" },
                    { 23, "VitaminC", "Milligrams" },
                    { 24, "VitaminE", "Milligrams" },
                    { 25, "ChromiumMicrograms", "Micrograms" },
                    { 26, "CobaltMicrograms", "Micrograms" },
                    { 27, "FluorideMicrograms", "Micrograms" },
                    { 28, "IodineMicrograms", "Micrograms" },
                    { 29, "LeadMicrograms", "Micrograms" },
                    { 30, "MercuryMicrograms", "Micrograms" },
                    { 31, "MolybdenumMicrograms", "Micrograms" },
                    { 32, "NickleMicrograms", "Micrograms" },
                    { 33, "SeleniumMicrograms", "Micrograms" },
                    { 34, "TinMicrograms", "Micrograms" },
                    { 35, "VitaminAequivalent", "Micrograms" },
                    { 36, "VitaminB7", "Micrograms" },
                    { 37, "VitaminB12", "Micrograms" },
                    { 38, "Folate", "Micrograms" },
                    { 39, "FolicAcidEquivalents", "Micrograms" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntries");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "UnitsConversion");
        }
    }
}
