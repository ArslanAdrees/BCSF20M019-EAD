using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Bridge
{
    // Implementor
    interface IImplementor
    {
        void OperationImp();
    }

    // ConcreteImplementor
    class ConcreteImplementorA : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("ConcreteImplementorA OperationImp");
        }
    }

    class ConcreteImplementorB : IImplementor
    {
        public void OperationImp()
        {
            Console.WriteLine("ConcreteImplementorB OperationImp");
        }
    }

    // Abstraction
    abstract class Abstraction
    {
        protected IImplementor Implementor;

        protected Abstraction(IImplementor implementor)
        {
            Implementor = implementor;
        }

        public abstract void Operation();
    }

    // RefinedAbstraction
    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(IImplementor implementor) : base(implementor) { }

        public override void Operation()
        {
            Implementor.OperationImp();
        }
    }

    class Program
    {
        static void Main()
        {
            IImplementor implementorA = new ConcreteImplementorA();
            IImplementor implementorB = new ConcreteImplementorB();

            Abstraction abstractionA = new RefinedAbstraction(implementorA);
            abstractionA.Operation();

            Abstraction abstractionB = new RefinedAbstraction(implementorB);
            abstractionB.Operation();
        }
    }


}






