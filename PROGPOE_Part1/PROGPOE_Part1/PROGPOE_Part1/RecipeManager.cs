using System;
using System.Collections.Generic;

namespace PROGPOE_Part1
{
    class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        // Method to add a new recipe
        public void AddNewRecipe()
        {
            Console.Write("Enter the recipe name: ");
            string recipeName = Console.ReadLine();

            Recipe recipe = new Recipe(recipeName);
            recipe.OnCaloriesExceeded += NotifyCaloriesExceeded;
            recipes.Add(recipe);

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = GetValidIntegerInput();
            for (int i = 0; i < ingredientCount; i++)
            {
                Console.Write($"Enter ingredient {i + 1} name: ");
                string name = Console.ReadLine();

                Console.Write($"Enter quantity for {name}: ");
                double quantity = GetValidDoubleInput();

                Console.Write($"Enter unit of measure for {name}: ");
                string unit = Console.ReadLine();

                Console.Write($"Enter calories for {name}: ");
                double calories = GetValidDoubleInput();

                Console.Write($"Enter food group for {name}: ");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(new Ingredient(name, quantity, unit, calories, foodGroup));
            }

            Console.Write("Enter the number of steps: ");
            int stepCount = GetValidIntegerInput();
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"Enter step {i + 1} description: ");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("You haven't added any recipes yet. Please add one first.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.Write("Select a recipe to display: ");
            int selectedRecipeIndex = GetValidIntegerInput() - 1;

            if (selectedRecipeIndex >= 0 && selectedRecipeIndex < recipes.Count)
            {
                recipes[selectedRecipeIndex].ShowRecipe();
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        // Method to adjust the recipe by scaling ingredient quantities
        public void AdjustRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("There's no recipe to adjust. Please add one first.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.Write("Select a recipe to adjust: ");
            int selectedRecipeIndex = GetValidIntegerInput() - 1;

            if (selectedRecipeIndex >= 0 && selectedRecipeIndex < recipes.Count)
            {
                Console.WriteLine("Enter the scaling factor (e.g., 0.5 for half, 2 for double, 3 for triple):");
                double factor = GetValidDoubleInput();
                if (factor > 0)
                {
                    recipes[selectedRecipeIndex].ScaleRecipe(factor);
                    Console.WriteLine($"Recipe {recipes[selectedRecipeIndex].Name} has been adjusted by a factor of {factor}.");
                }
                else
                {
                    Console.WriteLine("Invalid scaling factor. Please enter a positive number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        // Method to reset all ingredient quantities to their original values
        public void ResetQuantities()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe exists to reset quantities.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.Write("Select a recipe to reset quantities: ");
            int selectedRecipeIndex = GetValidIntegerInput() - 1;

            if (selectedRecipeIndex >= 0 && selectedRecipeIndex < recipes.Count)
            {
                recipes[selectedRecipeIndex].ResetQuantities();
                Console.WriteLine($"Quantities for recipe {recipes[selectedRecipeIndex].Name} have been reset to their original values.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        // Method to clear all ingredients and steps from the recipe
        public void ClearRecipe()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipe exists to clear.");
                return;
            }

            Console.WriteLine("Recipes:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            Console.Write("Select a recipe to clear: ");
            int selectedRecipeIndex = GetValidIntegerInput() - 1;

            if (selectedRecipeIndex >= 0 && selectedRecipeIndex < recipes.Count)
            {
                string recipeName = recipes[selectedRecipeIndex].Name;
                recipes[selectedRecipeIndex].ClearRecipe();
                recipes.RemoveAt(selectedRecipeIndex);
                Console.WriteLine($"Recipe {recipeName} cleared.");
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }

        private int GetValidIntegerInput()
        {
            int input;
            while (!int.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            return input;
        }

        // Utility method to get valid double input from the user
        private double GetValidDoubleInput()
        {
            double input;
            while (!double.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
            return input;
        }

        // Method to notify when recipe exceeds 300 calories
        private void NotifyCaloriesExceeded(string recipeName)
        {
            Console.WriteLine($"Warning: The recipe {recipeName} exceeds 300 calories.");
        }
    }
}
