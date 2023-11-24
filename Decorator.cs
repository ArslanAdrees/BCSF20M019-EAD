using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Decorator
{
    // Component
    interface IComponent
    {
        void Operation();
    }

    // ConcreteComponent
    class ConcreteComponent : IComponent
    {
        public void Operation()
        {
            Console.WriteLine("ConcreteComponent Operation");
        }
    }

    // Decorator
    abstract class Decorator : IComponent
    {
        protected IComponent Component;

        protected Decorator(IComponent component)
        {
            Component = component;
        }

        public virtual void Operation()
        {
            if (Component != null)
            {
                Component.Operation();
            }
        }
    }

    // ConcreteDecorator
    class ConcreteDecoratorA : Decorator
    {
        public ConcreteDecoratorA(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorA Operation");
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public ConcreteDecoratorB(IComponent component) : base(component) { }

        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("ConcreteDecoratorB Operation");
        }
    }

    class Program
    {
        static void Main()
        {
            IComponent component = new ConcreteComponent();
            Decorator decoratorA = new ConcreteDecoratorA(component);
            Decorator decoratorB = new ConcreteDecoratorB(decoratorA);

            decoratorB.Operation();
        }
    }

}







