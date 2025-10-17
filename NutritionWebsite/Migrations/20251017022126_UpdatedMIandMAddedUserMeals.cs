using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NutritionWebsite.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMIandMAddedUserMeals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredients_MealId",
                table: "MealIngredients");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Meals");

            migrationBuilder.CreateIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealIngredients_Ingredients_IngredientId",
                table: "MealIngredients");

            migrationBuilder.DropIndex(
                name: "IX_MealIngredients_IngredientId",
                table: "MealIngredients");

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_MealIngredients_Ingredients_MealId",
                table: "MealIngredients",
                column: "MealId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
