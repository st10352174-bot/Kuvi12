using System;

namespace PROGPOE_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate the RecipeManager which handles all recipe-related operations
            RecipeManager recipeManager = new RecipeManager();
            Console.WriteLine("Welcome to the Culinary Companion\n");

            bool isActive = true; // Flag to keep the application running
            while (isActive)
            {
                // Display options to the user
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1 - Add a new recipe");
                Console.WriteLine("2 - Display the recipe");
                Console.WriteLine("3 - Adjust the recipe");
                Console.WriteLine("4 - Reset quantities");
                Console.WriteLine("5 - Clear the recipe");
                Console.WriteLine("6 - Exit");
                Console.Write("Please choose an option: ");

                // Read user input and perform corresponding actions
                switch (Console.ReadLine())
                {
                    case "1":
                        // Add a new recipe
                        recipeManager.AddNewRecipe();
                        break;
                    case "2":
                        // Display the recipe
                        recipeManager.DisplayRecipe();
                        break;
                    case "3":
                        // Adjust the recipe by scaling ingredient quantities
                        recipeManager.AdjustRecipe();
                        break;
                    case "4":
                        // Reset ingredient quantities to their original values
                        recipeManager.ResetQuantities();
                        break;
                    case "5":
                        // Clear the recipe
                        recipeManager.ClearRecipe();
                        break;
                    case "6":
                        // Exit the application
                        isActive = false;
                        break;
                    default:
                        // Handle invalid options
                        Console.WriteLine("Invalid option selected. Please try again.");
                        break;

                }
            }
        }
    }
}
