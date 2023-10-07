using System;

public class EAD_Assgnment2
{
    public static void Main(string[] args)
    {

        void Task1()
        {
            Console.Write("Enter your first name: ");
            string first_name = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string last_name = Console.ReadLine();
            Console.Write("Your full name is: ");
            Console.WriteLine($"{first_name} {last_name}");
        }

        void Task2()
        {
            Console.Write("Enter a sentence: ");
            string sentence = Console.ReadLine();
            if (sentence.Length >= 5)
            {
                string lastFiveCharacters = "";
                for (int i = sentence.Length - 5; i <= sentence.Length - 1; i++)
                {
                    lastFiveCharacters = lastFiveCharacters + sentence[i];
                }

                Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
            }
            else
            {
                Console.WriteLine("Given sentence contains less than 5 characters!");
            }
        }

        void Task3()
        {
            double temperature;
            string city;
            Console.Write("Enter the name of your city: ");
            city = Console.ReadLine();
            Console.Write("Enter the current temperature in Celsius: ");
            string tem = Console.ReadLine();
            bool flag = double.TryParse(tem, out temperature);
            
            if(flag)
            {
                Console.WriteLine($"The temperature in {city} is {temperature} degrees Celsius.");
            }
            else
            {
                Console.WriteLine("You enterd invalid input for temperature!");
            }
            

        }

        void Task4()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.Write("Array elements: ");
            foreach (int number in numbers)
            {
                Console.Write(number + "  ");
            }

        }

        void Task5()
        {
            Console.WriteLine("\n---Task 5 (part A)---");
            string[] fruits = { "Apple", "Orange", "Peach", "Mango", "PineApple" };
            Console.Write("Fruits are: ");
            for (int i = 0; i < fruits.Length; i++)
            {
                Console.Write(fruits[i] + "  ");
            }
            //--------------------------------------------
            Console.WriteLine("\n\n---Task 5 (part B)---");
            string[] colors = { "Black", "White", "Red", "Yellow", "Green" };
            Console.Write("Colors are: ");
            foreach (string color in colors)
            {
                Console.Write(color + ", ");
            }

        }

        void Task6()
        {
            int[] scores = { 82, 30, 100, 70, 40, 60, 50, 130, 150, 35 };
            int sum = 0;
            int i = 0;
            do
            {
                sum = sum + scores[i];
                i++;
            } while (i < scores.Length);
            Console.WriteLine("Sum of all the test scores is " + sum);
        }

        void Task7()
        {
            int[] array = { 5, 8, 10, 2, 6 };
            int max = array[0];
            int i = 0;
            while(i<array.Length) 
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                i++;
            }
            Console.WriteLine("Maximum value in array is: " + max);
        }

        void Task8()
        {
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine("Original Array:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }

            int length = numbers.Length;
            for (int i = 0; i < length/2; i++)
            {
                int tempVar = numbers[i];
                numbers[i] = numbers[length-i-1];
                numbers[length-i-1] = tempVar;
            }

            Console.WriteLine("\nArray after Reversed:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }

        void Task9()
        {
            Console.WriteLine("\n---Task 9 (part A)---");
            int x = 42;
            object objX = x;
            int y = (int)objX;
            Console.WriteLine("The value of 'y' is: " + y);

            //--------------------------------------------
            Console.WriteLine("\n\n---Task 9 (part B)---");
            double doubleValue = 3.14159;
            object boxedValue = doubleValue;
            double unboxedValue = (double)boxedValue;
            Console.WriteLine("The value of 'unboxedValue' is: " + unboxedValue);

        }

        void Task10() 
        {
            Console.WriteLine("\n---Task 10 (part A)---");
            int[] numbers = { 1, 2, 3, 4, 5 };
            foreach (int num in numbers)
            {
                object boxedNum = num;
                int unboxedNum = (int)boxedNum;
                int squaredNum = unboxedNum * unboxedNum;
                Console.WriteLine($"Original: {num}, Squared: {squaredNum}");
            }
            //--------------------------------------------
            Console.WriteLine("\n\n---Task 10 (part B)---");
            List<object> mixedList = new List<object>();
            mixedList.Add(42);        
            mixedList.Add(3.14);      
            mixedList.Add('A');  

            foreach (object item in mixedList)
            {
                Console.WriteLine($"Element: {item}, Type: {item.GetType()}");
            }

            int intValue = (int)mixedList[0];
            double doubleValue = (double)mixedList[1];
            char charValue = (char)mixedList[2];

            Console.WriteLine("\nRetrieved Elements:");
            Console.WriteLine($"Integer Value: {intValue}, Type: {intValue.GetType()}");
            Console.WriteLine($"Double Value: {doubleValue}, Type: {doubleValue.GetType()}");
            Console.WriteLine($"Character Value: {charValue}, Type: {charValue.GetType()}");
        }

    

    void Task11()
    {
        Console.WriteLine("\n---Task 11 (part A)---");
        dynamic myVariable = 42;
        Console.WriteLine("myVariable = " + myVariable);
        myVariable = "Hello, Dynamic!";
        Console.WriteLine("myVariable = " + myVariable);

        //-----------------------------------------------

        Console.WriteLine("\n\n---Task 11 (part B)---");
        dynamic myVariable2;

        myVariable2 = 42;
        Console.WriteLine("Type of myVariable2 after assigning an integer: " + myVariable2.GetType());

        myVariable2 = 3.1415;
        Console.WriteLine("Type of myVariable2 after assigning a double: " + myVariable2.GetType());

        myVariable2 = DateTime.Now;
        Console.WriteLine("Type of myVariable2 after assigning a DateTime: " + myVariable2.GetType());

        myVariable2 = "Hello, dynamic!";
        Console.WriteLine("Type of myVariable2 after assigning a string: " + myVariable2.GetType());

    }



        string choice;
        do
        {

            Console.WriteLine("\n\nPress 1 for task-1");
            Console.WriteLine("Press 2 for task-2");
            Console.WriteLine("Press 3 for task-3");
            Console.WriteLine("Press 4 for task-4");
            Console.WriteLine("Press 5 for task-5");
            Console.WriteLine("Press 6 for task-6");
            Console.WriteLine("Press 7 for task-7");
            Console.WriteLine("Press 8 for task-8");
            Console.WriteLine("Press 9 for task-9");
            Console.WriteLine("Press 10 for task-10");
            Console.WriteLine("Press 11 for task-11");
            Console.WriteLine("Press 12 to exit from program");

            Console.Write("\nEnter your choice: ");
            choice = Console.ReadLine();
            Console.WriteLine("\n");
            if (choice == "1")
            {
                Task1();
            }
            else if (choice == "2")
            {
                Task2();
            }
            else if (choice == "3")
            {
                Task3();
            }
            else if (choice == "4")
            {
                Task4();
            }
            else if (choice == "5")
            {
                Task5();
            }
            else if (choice == "6")
            {
                Task6();
            }
            else if (choice == "7")
            {
                Task7();
            }
            else if (choice == "8")
            {
                Task8();
            }
            else if (choice == "9")
            {
                Task9();
            }
            else if (choice == "10")
            {
                Task10();
            }
            else if (choice == "11")
            {
                Task11();
            }
            else if(choice=="12")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ooops! You entered invalid input. Please enter valid input!");
            }
        } while (true);
    }
        
}









        





     




