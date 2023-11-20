using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Prototype
{
    // Example 1
    // Prototype interface
    public interface IPrototype
    {
        IPrototype Clone();
    }

    // Concrete prototype
    public class ConcretePrototype : IPrototype
    {
        private string attribute;

        public ConcretePrototype(string attribute)
        {
            this.attribute = attribute;
        }

        public IPrototype Clone()
        {
            return new ConcretePrototype(attribute);
        }

        public void Display()
        {
            Console.WriteLine("Attribute: " + attribute);
        }
    }

    //------------------------------------------------------------
    // Example 2
    
    // Prototype interface
    public interface IDocumentPrototype
    {
        IDocumentPrototype Clone();
        void Print();
    }

    // Concrete prototype 1
    public class Resume : IDocumentPrototype
    {
        private string name;
        private string education;

        public Resume(string name, string education)
        {
            this.name = name;
            this.education = education;
        }

        public IDocumentPrototype Clone()
        {
            return new Resume(name, education);
        }

        public void Print()
        {
            Console.WriteLine($"Resume - Name: {name}, Education: {education}");
        }
    }

    // Concrete prototype 2
    public class Proposal : IDocumentPrototype
    {
        private string title;
        private string content;

        public Proposal(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public IDocumentPrototype Clone()
        {
            return new Proposal(title, content);
        }

        public void Print()
        {
            Console.WriteLine($"Proposal - Title: {title}, Content: {content}");
        }
    }

    // Client
    public class DocumentClient
    {
        public IDocumentPrototype CreateDocument(IDocumentPrototype prototype)
        {
            return prototype.Clone();
        }
    }


    class Program
    {
        static void Main()
        {
            int choice;
            Console.WriteLine("You are learning Prototype design pattern!");
            do
            {
                Console.WriteLine("Press 1 for Example 1.\nPress 2 for Example 2.");
                Console.Write("Enter your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    ConcretePrototype prototype = new ConcretePrototype("Prototype 1");
                    ConcretePrototype clonedPrototype = (ConcretePrototype)prototype.Clone();

                    prototype.Display();        // Output: Attribute: Prototype 1
                    clonedPrototype.Display();  // Output: Attribute: Prototype 1

                    // Modify the cloned prototype
                    clonedPrototype = (ConcretePrototype)prototype.Clone();
                    clonedPrototype.Display();  // Output: Attribute: Prototype 1
                    clonedPrototype = new ConcretePrototype("Modified Prototype");
                    clonedPrototype.Display();  // Output: Attribute: Modified Prototype
                }
                else if (choice == 2)
                {
                    DocumentClient documentClient = new DocumentClient();

                    // Create an original resume
                    IDocumentPrototype originalResume = new Resume("John Doe", "Computer Science");

                    // Clone the original resume
                    IDocumentPrototype clonedResume = documentClient.CreateDocument(originalResume);

                    // Create an original proposal
                    IDocumentPrototype originalProposal = new Proposal("Project Proposal", "Detailed project plan.");

                    // Clone the original proposal
                    IDocumentPrototype clonedProposal = documentClient.CreateDocument(originalProposal);

                    // Print original and cloned documents
                    Console.WriteLine("Original Documents:");
                    originalResume.Print();
                    originalProposal.Print();

                    Console.WriteLine("\nCloned Documents:");
                    clonedResume.Print();
                    clonedProposal.Print();
                }
                else
                {
                    Console.WriteLine("Please enter valid choice!");
                }
            } while (choice != 1 || choice != 2);
        }
    }
}

