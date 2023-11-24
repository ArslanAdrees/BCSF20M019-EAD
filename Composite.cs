using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Composite
{
    // Component
    interface IComponent
    {
        void Display();
    }

    // Leaf
    class Leaf : IComponent
    {
        private readonly string name;

        public Leaf(string name)
        {
            this.name = name;
        }

        public void Display()
        {
            Console.WriteLine($"Leaf: {name}");
        }
    }

    // Composite
    class Composite : IComponent
    {
        private readonly List<IComponent> children = new List<IComponent>();

        public void Add(IComponent component)
        {
            children.Add(component);
        }

        public void Display()
        {
            foreach (var child in children)
            {
                child.Display();
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var root = new Composite();
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var composite = new Composite();
            composite.Add(new Leaf("Leaf C"));
            composite.Add(new Leaf("Leaf D"));

            root.Add(composite);

            root.Display();
        }
    }

}



