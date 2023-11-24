using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Flyweight
{
    // Flyweight
    interface IFlyweight
    {
        void Operation();
    }

    // ConcreteFlyweight
    class ConcreteFlyweight : IFlyweight
    {
        private readonly string intrinsicState;

        public ConcreteFlyweight(string intrinsicState)
        {
            this.intrinsicState = intrinsicState;
        }

        public void Operation()
        {
            Console.WriteLine($"ConcreteFlyweight: {intrinsicState}");
        }
    }

    // FlyweightFactory
    class FlyweightFactory
    {
        private readonly Dictionary<string, IFlyweight> flyweights = new Dictionary<string, IFlyweight>();

        public IFlyweight GetFlyweight(string key)
        {
            if (!flyweights.TryGetValue(key, out var flyweight))
            {
                flyweight = new ConcreteFlyweight(key);
                flyweights[key] = flyweight;
            }

            return flyweight;
        }
    }

    class Program
    {
        static void Main()
        {
            FlyweightFactory factory = new FlyweightFactory();

            IFlyweight flyweight1 = factory.GetFlyweight("A");
            IFlyweight flyweight2 = factory.GetFlyweight("B");

            flyweight1.Operation();
            flyweight2.Operation();
        }
    }

}




