using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Builder
{
    // Example 1
    // Product
    public class Building
    {
        public string Foundation { get; set; }
        public string Structure { get; set; }
        public string Roof { get; set; }
    }

    // Builder interface
    public interface IBuildingBuilder
    {
        void BuildFoundation();
        void BuildStructure();
        void BuildRoof();
        Building GetBuilding();
    }

    // Concrete Builder 1
    public class HouseBuilder : IBuildingBuilder
    {
        private Building house = new Building();

        public void BuildFoundation()
        {
            house.Foundation = "House Foundation";
        }

        public void BuildStructure()
        {
            house.Structure = "House Structure";
        }

        public void BuildRoof()
        {
            house.Roof = "House Roof";
        }

        public Building GetBuilding()
        {
            return house;
        }
    }

    // Concrete Builder 2
    public class OfficeBuilder : IBuildingBuilder
    {
        private Building office = new Building();

        public void BuildFoundation()
        {
            office.Foundation = "Office Foundation";
        }

        public void BuildStructure()
        {
            office.Structure = "Office Structure";
        }

        public void BuildRoof()
        {
            office.Roof = "Office Roof";
        }

        public Building GetBuilding()
        {
            return office;
        }
    }

    // Director
    public class BuildingDirector
    {
        public void Construct(IBuildingBuilder builder)
        {
            builder.BuildFoundation();
            builder.BuildStructure();
            builder.BuildRoof();
        }
    }

    //------------------------------------------------------------
    // Example 2
    // Product
    public class Meal
    {
        public string MainCourse { get; set; }
        public string SideDish { get; set; }
        public string Drink { get; set; }
        public string Dessert { get; set; }
    }

    // Builder interface
    public interface IMealBuilder
    {
        void BuildMainCourse();
        void BuildSideDish();
        void BuildDrink();
        void BuildDessert();
        Meal GetMeal();
    }

    // Concrete Builder 1
    public class HealthyMealBuilder : IMealBuilder
    {
        private Meal meal = new Meal();

        public void BuildMainCourse()
        {
            meal.MainCourse = "Grilled Chicken Salad";
        }

        public void BuildSideDish()
        {
            meal.SideDish = "Steamed Vegetables";
        }

        public void BuildDrink()
        {
            meal.Drink = "Water";
        }

        public void BuildDessert()
        {
            meal.Dessert = "Fruit Salad";
        }

        public Meal GetMeal()
        {
            return meal;
        }
    }

    // Concrete Builder 2
    public class FastFoodMealBuilder : IMealBuilder
    {
        private Meal meal = new Meal();

        public void BuildMainCourse()
        {
            meal.MainCourse = "Cheeseburger";
        }

        public void BuildSideDish()
        {
            meal.SideDish = "French Fries";
        }

        public void BuildDrink()
        {
            meal.Drink = "Cola";
        }

        public void BuildDessert()
        {
            meal.Dessert = "Apple Pie";
        }

        public Meal GetMeal()
        {
            return meal;
        }
    }

    // Director
    public class MealDirector
    {
        public void Construct(IMealBuilder builder)
        {
            builder.BuildMainCourse();
            builder.BuildSideDish();
            builder.BuildDrink();
            builder.BuildDessert();
        }
    }


    class Program
    {
        static void Main()
        {
            int choice;
            Console.WriteLine("You are learning Builder design pattern!");
            do
            {
                Console.WriteLine("Press 1 for Example 1.\nPress 2 for Example 2.");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    BuildingDirector director = new BuildingDirector();

                    IBuildingBuilder houseBuilder = new HouseBuilder();
                    director.Construct(houseBuilder);
                    Building house = houseBuilder.GetBuilding();

                    IBuildingBuilder officeBuilder = new OfficeBuilder();
                    director.Construct(officeBuilder);
                    Building office = officeBuilder.GetBuilding();

                    Console.WriteLine("House:");
                    Console.WriteLine($"Foundation: {house.Foundation}");
                    Console.WriteLine($"Structure: {house.Structure}");
                    Console.WriteLine($"Roof: {house.Roof}");

                    Console.WriteLine("\nOffice:");
                    Console.WriteLine($"Foundation: {office.Foundation}");
                    Console.WriteLine($"Structure: {office.Structure}");
                    Console.WriteLine($"Roof: {office.Roof}");
                }
                else if (choice == 2)
                {
                    MealDirector director = new MealDirector();

                    IMealBuilder healthyMealBuilder = new HealthyMealBuilder();
                    director.Construct(healthyMealBuilder);
                    Meal healthyMeal = healthyMealBuilder.GetMeal();

                    IMealBuilder fastFoodMealBuilder = new FastFoodMealBuilder();
                    director.Construct(fastFoodMealBuilder);
                    Meal fastFoodMeal = fastFoodMealBuilder.GetMeal();

                    Console.WriteLine("Healthy Meal:");
                    Console.WriteLine($"Main Course: {healthyMeal.MainCourse}");
                    Console.WriteLine($"Side Dish: {healthyMeal.SideDish}");
                    Console.WriteLine($"Drink: {healthyMeal.Drink}");
                    Console.WriteLine($"Dessert: {healthyMeal.Dessert}");

                    Console.WriteLine("\nFast Food Meal:");
                    Console.WriteLine($"Main Course: {fastFoodMeal.MainCourse}");
                    Console.WriteLine($"Side Dish: {fastFoodMeal.SideDish}");
                    Console.WriteLine($"Drink: {fastFoodMeal.Drink}");
                    Console.WriteLine($"Dessert: {fastFoodMeal.Dessert}");
                }
                else
                {
                    Console.WriteLine("Please enter valid choice!");
                }
            } while (choice != 1 || choice != 2);
        }
    }
}

