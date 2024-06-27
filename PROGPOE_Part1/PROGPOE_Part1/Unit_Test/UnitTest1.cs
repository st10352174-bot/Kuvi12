namespace Unit_Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PROGPOE_Part1;
    using System;

    namespace PROGPOE_Part1.Tests
    {
        [TestClass]
        public class RecipeTests
        {
            [TestMethod]
            public void Test_CaloriesDoNotExceed300()
            {
                // Arrange
                var recipe = new Recipe("Test Recipe");
                recipe.OnCaloriesExceeded += (name) => throw new Exception("Calories exceeded");

                // Act
                var ingredient1 = new Ingredient("Ingredient 1", 1, "unit", 100, "Vegetable");
                var ingredient2 = new Ingredient("Ingredient 2", 1, "unit", 150, "Protein");
                var ingredient3 = new Ingredient("Ingredient 3", 1, "unit", 50, "Carbohydrate");

                recipe.AddIngredient(ingredient1);
                recipe.AddIngredient(ingredient2);
                recipe.AddIngredient(ingredient3);

                // Assert
                double totalCalories = 100 + 150 + 50;
                Assert.AreEqual(totalCalories, GetTotalCalories(recipe));
            }

            [TestMethod]
            [ExpectedException(typeof(Exception), "Calories exceeded")]
            public void Test_CaloriesExceed300()
            {
                // Arrange
                var recipe = new Recipe("High Calorie Recipe");
                recipe.OnCaloriesExceeded += (name) => throw new Exception("Calories exceeded");

                // Act
                var ingredient1 = new Ingredient("Ingredient 1", 1, "unit", 200, "Protein");
                var ingredient2 = new Ingredient("Ingredient 2", 1, "unit", 150, "Carbohydrate");

                recipe.AddIngredient(ingredient1);
                recipe.AddIngredient(ingredient2);

                // Assert
                // Exception is expected, so no need for further assertions
            }

            // Private helper method to access the private GetTotalCalories method in the Recipe class
            private double GetTotalCalories(Recipe recipe)
            {
                var getTotalCaloriesMethod = typeof(Recipe).GetMethod("GetTotalCalories", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return (double)getTotalCaloriesMethod.Invoke(recipe, null);
            }
        }
    }

}