using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedColumnsOfMealIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "MealIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                table: "MealIngredients",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredients_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredients_MealId",
                table: "MealIngredients");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "MealIngredients");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MealIngredients");
        }
    }
}
