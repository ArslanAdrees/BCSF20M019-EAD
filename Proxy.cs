using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Proxy
{
    // Subject
    interface ISubject
    {
        void Request();
    }

    // RealSubject
    class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject Request");
        }
    }

    // Proxy
    class Proxy : ISubject
    {
        private RealSubject realSubject;

        public void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }

    class Program
    {
        static void Main()
        {
            ISubject proxy = new Proxy();
            proxy.Request();
        }
    }

}



