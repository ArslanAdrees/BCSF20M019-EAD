using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Facade
{
    // Subsystem
    class Subsystem1
    {
        public void Operation1()
        {
            Console.WriteLine("Subsystem1 Operation1");
        }
    }

    class Subsystem2
    {
        public void Operation2()
        {
            Console.WriteLine("Subsystem2 Operation2");
        }
    }

    // Facade
    class Facade
    {
        private readonly Subsystem1 subsystem1;
        private readonly Subsystem2 subsystem2;

        public Facade()
        {
            subsystem1 = new Subsystem1();
            subsystem2 = new Subsystem2();
        }

        public void Operation()
        {
            subsystem1.Operation1();
            subsystem2.Operation2();
        }
    }

    class Program
    {
        static void Main()
        {
            Facade facade = new Facade();
            facade.Operation();
        }
    }


}





