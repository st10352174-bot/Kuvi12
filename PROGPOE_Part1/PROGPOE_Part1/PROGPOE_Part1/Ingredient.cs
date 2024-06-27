using System;

namespace PROGPOE_Part1
{
    // Class representing a single ingredient in a recipe
    class Ingredient
    {
        public string Name { get; }
        public double Quantity { get; set; }
        public string Unit { get; }
        public double Calories { get; }
        public string FoodGroup { get; }
        private double originalQuantity;

        // Constructor to initialize the ingredient properties
        public Ingredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Unit = unit;
            Calories = calories;
            FoodGroup = foodGroup;
            originalQuantity = quantity;
        }

        // Method to scale the ingredient quantity by a factor
        public void Scale(double factor)
        {
            Quantity *= factor;
        }

        // Method to reset the ingredient quantity
        public void Reset()
        {
            Quantity = originalQuantity;
        }
    }
}
