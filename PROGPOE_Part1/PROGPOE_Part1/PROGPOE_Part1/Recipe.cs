using System;
using System.Collections.Generic;

namespace PROGPOE_Part1
{
    class Recipe
    {
        public string Name { get; }
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();

        public event Action<string> OnCaloriesExceeded;

        // Constructor to initialize the recipe name
        public Recipe(string name)
        {
            Name = name;
        }

        // Methods to add an ingredient and step to the recipe
        public void AddIngredient(Ingredient ingredient)
        {
            ingredients.Add(ingredient);
            if (GetTotalCalories() > 300)
            {
                OnCaloriesExceeded?.Invoke(Name);
            }
        }

        public void AddStep(string step)
        {
            steps.Add(step);
        }

        // Method to display the complete recipe
        public void ShowRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("Steps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        // Method to scale the recipe by a given factor, adjusting ingredient quantities
        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Scale(factor);
            }
        }

        // Method to reset all ingredient quantities to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.Reset();
            }
        }

        // Method to clear all ingredients and steps from the recipe
        public void ClearRecipe()
        {
            ingredients.Clear();
            steps.Clear();
        }

        // Method to calculate total calories of the recipe
        private double GetTotalCalories()
        {
            double totalCalories = 0;
            foreach (var ingredient in ingredients)
            {
                totalCalories += ingredient.Quantity * ingredient.Calories;
            }
            return totalCalories;
        }
    }
}
