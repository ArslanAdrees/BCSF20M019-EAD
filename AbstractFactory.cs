using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace AbstractFactory
{
    // Example 1
    // Abstract Product A
    public interface IButton
    {
        void Display();
    }

    // Concrete Product A1
    public class WindowsButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("Windows Button");
        }
    }

    // Concrete Product A2
    public class MacOSButton : IButton
    {
        public void Display()
        {
            Console.WriteLine("MacOS Button");
        }
    }

    // Abstract Product B
    public interface ICheckbox
    {
        void Display();
    }

    // Concrete Product B1
    public class WindowsCheckbox : ICheckbox
    {
        public void Display()
        {
            Console.WriteLine("Windows Checkbox");
        }
    }

    // Concrete Product B2
    public class MacOSCheckbox : ICheckbox
    {
        public void Display()
        {
            Console.WriteLine("MacOS Checkbox");
        }
    }

    // Abstract Factory
    public interface IGuiFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // Concrete Factory 1
    public class WindowsGuiFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new WindowsButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new WindowsCheckbox();
        }
    }

    // Concrete Factory 2
    public class MacOSGuiFactory : IGuiFactory
    {
        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public ICheckbox CreateCheckbox()
        {
            return new MacOSCheckbox();
        }
    }

    //------------------------------------------------------------------
    // Example 2

    // Abstract Product A
    public interface IChair
    {
        void Sit();
    }

    // Concrete Product A1
    public class ModernChair : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Sitting on a modern chair");
        }
    }

    // Concrete Product A2
    public class VictorianChair : IChair
    {
        public void Sit()
        {
            Console.WriteLine("Sitting on a Victorian chair");
        }
    }

    // Abstract Product B
    public interface ICoffeeTable
    {
        void PutCoffee();
    }

    // Concrete Product B1
    public class ModernCoffeeTable : ICoffeeTable
    {
        public void PutCoffee()
        {
            Console.WriteLine("Putting coffee on a modern coffee table");
        }
    }

    // Concrete Product B2
    public class VictorianCoffeeTable : ICoffeeTable
    {
        public void PutCoffee()
        {
            Console.WriteLine("Putting coffee on a Victorian coffee table");
        }
    }

    // Abstract Factory
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ICoffeeTable CreateCoffeeTable();
    }

    // Concrete Factory 1
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ICoffeeTable CreateCoffeeTable()
        {
            return new ModernCoffeeTable();
        }
    }

    // Concrete Factory 2
    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ICoffeeTable CreateCoffeeTable()
        {
            return new VictorianCoffeeTable();
        }
    }


    class Program
    {
        static void Main()
        {
            int choice;
            Console.WriteLine("You are learning Abstract Factory design pattern!");
            do
            {
                Console.WriteLine("Press 1 for Example 1.\nPress 2 for Example 2.");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    // Create Windows GUI components
                    IGuiFactory windowsFactory = new WindowsGuiFactory();
                    IButton windowsButton = windowsFactory.CreateButton();
                    ICheckbox windowsCheckbox = windowsFactory.CreateCheckbox();

                    windowsButton.Display();     // Output: Windows Button
                    windowsCheckbox.Display();   // Output: Windows Checkbox

                    // Create MacOS GUI components
                    IGuiFactory macosFactory = new MacOSGuiFactory();
                    IButton macosButton = macosFactory.CreateButton();
                    ICheckbox macosCheckbox = macosFactory.CreateCheckbox();

                    macosButton.Display();     // Output: MacOS Button
                    macosCheckbox.Display();   // Output: MacOS Checkbox
                }
                else if (choice == 2)
                {
                    // Create Modern furniture
                    IFurnitureFactory modernFactory = new ModernFurnitureFactory();
                    IChair modernChair = modernFactory.CreateChair();
                    ICoffeeTable modernCoffeeTable = modernFactory.CreateCoffeeTable();

                    modernChair.Sit();               // Output: Sitting on a modern chair
                    modernCoffeeTable.PutCoffee();   // Output: Putting coffee on a modern coffee table

                    // Create Victorian furniture
                    IFurnitureFactory victorianFactory = new VictorianFurnitureFactory();
                    IChair victorianChair = victorianFactory.CreateChair();
                    ICoffeeTable victorianCoffeeTable = victorianFactory.CreateCoffeeTable();

                    victorianChair.Sit();                // Output: Sitting on a Victorian chair
                    victorianCoffeeTable.PutCoffee();    // Output: Putting coffee on a Victorian coffee table
                }
                else
                {
                    Console.WriteLine("Please enter valid choice!");
                }
            } while (choice != 1 || choice != 2);
        }
    }
}

