using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Adapter
{
    // Target
    interface ITarget
    {
        void Request();
    }

    // Adaptee
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("SpecificRequest called");
        }
    }

    // Adapter
    class Adapter : ITarget
    {
        private readonly Adaptee adaptee;

        public Adapter(Adaptee adaptee)
        {
            this.adaptee = adaptee;
        }

        public void Request()
        {
            adaptee.SpecificRequest();
        }
    }

    class Program
    {
        static void Main()
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            target.Request();
        }
    }

}


