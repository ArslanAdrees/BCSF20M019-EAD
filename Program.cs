using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Security.Cryptography;

public class EAD_Assignment03
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author = "Unknown")
        {
            Title = title;
            Author = author;
        }
        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
        }

    }
    public class MyList<T>
    {

        public List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }     
        public void Remove(T item)
        {
            items.Remove(item);
        }
        public void Display()
        {
            
            foreach (T item in items)
            {
                Console.Write(item + "  ");
            }
        }
    }

    class StudentDatabase
    {
        private Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

        // Add student records to the dictionary
        public void AddStudent(int studentID, string name)
        {
            studentDictionary[studentID] = name;
        }

        // Retrieve the student's name by student ID
        public string GetStudentName(int studentID)
        {
            if (studentDictionary.ContainsKey(studentID))
            {
                return studentDictionary[studentID];
            }
            else
            {
                return "Student ID not found";
            }
        }

        // Display the entire student database
        public void DisplayDatabase()
        {
            Console.WriteLine("Student Database:");
            foreach (var std in studentDictionary)
            {
                Console.WriteLine($"Student ID: {std.Key}, Name: {std.Value}");
            }
        }

        // Update a student's name by student ID
        public void UpdateStudentName(int studentID, string newName)
        {
            if (studentDictionary.ContainsKey(studentID))
            {
                studentDictionary[studentID] = newName;
                Console.WriteLine("Student name updated successfully.");
            }
            else
            {
                Console.WriteLine("Student ID not found. Name not updated.");
            }
        }
    }




    //----------------------------------------------------
    //                Task1
    //----------------------------------------------------

    public void Greet(string greeting = "Hello", string name = "World")
    {
        Console.WriteLine($"{greeting}, {name}!");
    }

    public double CalculateArea(double length = 1.0, double width = 1.0)
    {
        return length * width;
    }
    public int AddNumbers(int a, int b)
    {
        return a + b;
    }
    public int AddNumbers(int a, int b, int c = 0)
    {
        return a + b + c;
    }
    public void BookDetail()
    {
        Book book1 = new Book("Starting out with C++");
        Console.WriteLine("Book detail without specifying author!");
        book1.DisplayDetails();
        Book book2 = new Book("Starting out with C++", "Toni Gaddies");
        Console.WriteLine("Book detail with specifying author!");
        book2.DisplayDetails();
    }

    //---------------------------------------------------
    //                  Task2
    //---------------------------------------------------
    public void Task2_A()
    {
        MyList<int> List = new MyList<int>();
        List.Add(10);
        List.Add(20);
        List.Add(30);
        List.Add(40);
        List.Add(50);
        Console.WriteLine("Current list: ");
        List.Display();
        List.Remove(20);
        Console.WriteLine("\nList after removing 20: ");
        List.Display();
        Console.WriteLine("\nDisplay list: ");
        List.Display();
    }

    public void Task2_B<T>(ref T a,ref T b)
    {

        T temp = a;
        a = b;
        b = temp;
    }

    public void Sum<T>(T[] arr)
    {
        
        foreach (T item in arr)
        {
            Console.Write(item + "  ");

        }
        if (Convert.ToString(arr.GetType()) != "System.Int32[]" && Convert.ToString(arr.GetType()) != "System.Double[]" && Convert.ToString(arr.GetType()) != "System.Int64[]")
        {
            Console.WriteLine("\nThis data type does not support addition!");
        }
        else
        {
            T sum = default(T);
            for (int i = 0; i < arr.Length; i++)
            {
                sum = (T)Convert.ChangeType(Convert.ToDouble(sum) + Convert.ToDouble(arr[i]), typeof(T));
            }
            Console.WriteLine($"\nSum of array elements is: {sum}");

        }
    }

    public void Task2_D()
    {
        StudentDatabase student = new StudentDatabase();

        // Add student records to the dictionary
        student.AddStudent(101, "Alice");
        student.AddStudent(102, "Bob");
        student.AddStudent(103, "Charlie");
        student.AddStudent(104, "David");

        string selection;
        do
        {
            Console.WriteLine("\n\nPress 1 to search Student by ID");
            Console.WriteLine("Press 2 to display all the students");
            Console.WriteLine("Press 3 to update Student name by ID");
            Console.WriteLine("Press 4 to exit from Student Dictionary");
            Console.Write("Enter your choice: ");
            selection = Console.ReadLine();
            Console.WriteLine("\n");

            if (selection == "1")
            {
                // Search and display a student's name by student ID
                Console.Write("Enter a student ID to retrieve the name: ");
                if (int.TryParse(Console.ReadLine(), out int inputID))
                {
                    string studentName = student.GetStudentName(inputID);
                    Console.WriteLine($"Student Name: {studentName}");
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }

            else if (selection == "2")
            {
                // Display the entire student database
                student.DisplayDatabase();
            }

            else if (selection == "3")
            {
                // Update a student's name by student ID
                Console.Write("Enter a student ID to update the name: ");
                if (int.TryParse(Console.ReadLine(), out int updateID))
                {
                    Console.Write("Enter the new name: ");
                    string newName = Console.ReadLine();
                    student.UpdateStudentName(updateID, newName);
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            else if(selection=="4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Ooops! You entered invalid input. Please enter valid input!");
            }
            

        }while (true);
    }
    


//###################################################
    public static void Main(string[] args)
    {

         string choice;
        EAD_Assignment03 task = new EAD_Assignment03();
        do
        {
            Console.WriteLine("\n\nPress 1 for task-1(part A)");
            Console.WriteLine("Press 2 for task-1(part B)");
            Console.WriteLine("Press 3 for task-1(part C)");
            Console.WriteLine("Press 4 for task-1(part D)");
            Console.WriteLine("Press 5 for task-2(part A)");
            Console.WriteLine("Press 6 for task-2(part B)");
            Console.WriteLine("Press 7 for task-2(part C)");
            Console.WriteLine("Press 8 for task-2(part D)");
            Console.WriteLine("Press 9 to exit from program");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            Console.WriteLine("\n");
            if(choice == "1")
            {
                Console.WriteLine("Without passing data!");
                task.Greet();
                Console.WriteLine("With passig data!");
                task.Greet("Hye", "Ali");
            }
            else if(choice == "2")
            {
                Console.WriteLine("Area of Rectangle!");
                Console.WriteLine("Without passing data!");
                Console.WriteLine(task.CalculateArea());
                Console.WriteLine("With passing data!");
                Console.WriteLine(task.CalculateArea(2.6, 5.5));
            }
            else if(choice=="3")
            {
                Console.WriteLine("Sum of numbers!");
                Console.Write("With two parameters:");
                Console.WriteLine(task.AddNumbers(2, 5));
                Console.Write("With two parameters, third parameter is optional:");
                Console.WriteLine(task.AddNumbers(2, 5));
                Console.Write("With three parameters:");
                Console.WriteLine(task.AddNumbers(2, 5, 3));
            }
            else if(choice=="4")
            {
                task.BookDetail();
            }
            else if(choice=="5")
            {
                task.Task2_A();
            }
            else if(choice=="6")
            {

                int a = 10, b = 20;
                Console.WriteLine($"Before Swaping: a = {a}, b = {b}");
                task.Task2_B(ref a, ref b);
                Console.WriteLine($"After Swaping: a = {a}, b = {b}");
                string x = "Good", y = "Bad";
                Console.WriteLine("\n");
                Console.WriteLine($"Before Swaping: x = {x}, y = {y}");
                task.Task2_B(ref x, ref y);
                Console.WriteLine($"After Swaping: x = {x}, y = {y}");
            }
            else if(choice=="7")
            {
                int[] array1 = {1,2,3,4,5};
                Console.Write("Array of Integer : ");
                task.Sum<int>(array1);
                Console.WriteLine("\n");

                long[] array2 = { 1576, 53738, 9854437, 575, 38454 };
                Console.Write("Array of Long : ");
                task.Sum<long>(array2);
                Console.WriteLine("\n");

                double[] array3 = { 12.7635, 28.2458, 31.8967555, 4.0934768, 5.56234 };
                Console.Write("Array of Double : ");
                task.Sum<double>(array3);
                Console.WriteLine("\n");

                string[] array4 = { "I", "am", "a", "boy." };
                Console.Write("Array of String : ");
                task.Sum<string>(array4);

            }
            else if(choice=="8")
            {
                task.Task2_D();
            }
            else if(choice=="9")
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


