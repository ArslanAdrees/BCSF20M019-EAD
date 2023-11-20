using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Factory
{
    // Example 1
    public interface IProduct
    {
        void Display();
    }

    public class ConcreteProductA : IProduct
    {
        public void Display()
        {
            Console.WriteLine("Product A");
        }
    }

    public class ConcreteProductB : IProduct
    {
        public void Display()
        {
            Console.WriteLine("Product B");
        }
    }

    public class SimpleFactory
    {
        public static IProduct CreateProduct(string productName)
        {
            switch (productName)
            {
                case "A":
                { 
                   return new ConcreteProductA();
                }
                case "B":
                { 
                   return new ConcreteProductB();
                }
                default:
                {
                   throw new ArgumentException("Invalid product name");
                }
            }
        }
    }

    //------------------------------------------------------------
    // Example 2
    // Logger interface
    public interface ILogger
    {
        void Log(string message);
    }

    // Concrete loggers
    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to file: {message}");
        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Logging to console: {message}");
        }
    }

    public class LoggingProviderFactory
    {
        public ILogger CreateLogger(string provider)
        {
            switch (provider)
            {
                case "File":
                { 
                   return new FileLogger(); 
                }
                case "Console":
                { 
                   return new ConsoleLogger(); 
                }
                default:
                { 
                   throw new ArgumentException("Invalid logging provider"); 
                }
            }
        }
    }

    class Program
    {
        static void Main()
        {
            int choice;
            Console.WriteLine("You are learning Factory design pattern!");

                do
                { 

                    Console.WriteLine("Press 1 for Example 1.\nPress 2 for Example 2.");
                    Console.Write("Enter your choice : ");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1)
                    {
                        SimpleFactory factory = new SimpleFactory();

                        IProduct productA = SimpleFactory.CreateProduct("A");
                        productA.Display(); // Output: Product A

                        IProduct productB = SimpleFactory.CreateProduct("B");
                        productB.Display(); // Output: Product B
                    }
                    else if (choice == 2)
                    {

                        LoggingProviderFactory factory = new LoggingProviderFactory();

                        ILogger fileLogger = factory.CreateLogger("File");
                        fileLogger.Log("This message will be logged to a file.");

                        ILogger consoleLogger = factory.CreateLogger("Console");
                        consoleLogger.Log("This message will be logged to the console.");

                    }
                    else
                    {
                        Console.WriteLine("Please enter valid choice!");
                    }
                }while(choice != 1 || choice != 2);
          
        }
    }
}

