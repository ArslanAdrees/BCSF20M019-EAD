using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Singleton
{
    // Example 1
    public class SingletonExample1
    {
        private static SingletonExample1 instance;

        private SingletonExample1() { }

        public static SingletonExample1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonExample1();
                }
                return instance;
            }
        }
        public void PrintMessage()
        {
            Console.WriteLine("Singleton instance is created and used.");
        }
    }
    //------------------------------------------------------------
    // Example 2
    public class ThreadSafeSingleton
    {
        private static ThreadSafeSingleton instance;
        private static readonly object lockObject = new object();

        private ThreadSafeSingleton() { }

        public static ThreadSafeSingleton Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ThreadSafeSingleton();
                    }
                    return instance;
                }
            }
        }

        public void PrintMessage()
        {
            Console.WriteLine("Thread-Safe Singleton instance is created and used.");
        }
    }

    class Program
    {
        static void Main()
        {
            int choice;
            Console.WriteLine("You are learning Singleton design pattern!");
            do
            {
                Console.WriteLine("Press 1 for Example 1.\nPress 2 for Example 2.");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    SingletonExample1 instance1 = SingletonExample1.Instance;
                    instance1.PrintMessage();

                    SingletonExample1 instance2 = SingletonExample1.Instance;
                    instance2.PrintMessage();

                    // Both instances point to the same object
                    Console.WriteLine(instance1 == instance2);
                }
                else if(choice==2)
                {
                    ThreadSafeSingleton instance1 = ThreadSafeSingleton.Instance;
                    instance1.PrintMessage();

                    ThreadSafeSingleton instance2 = ThreadSafeSingleton.Instance;
                    instance2.PrintMessage();

                    // Both instances point to the same object
                    Console.WriteLine(instance1 == instance2);

                }
                else
                {
                    Console.WriteLine("Please enter valid choice!");
                }
            } while (choice != 1 ||choice != 2);
        }
    }
}

