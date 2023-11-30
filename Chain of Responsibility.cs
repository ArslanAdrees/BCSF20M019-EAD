using System;

// Handler interface
abstract class Approver
{
    protected Approver successor;

    public void SetSuccessor(Approver successor)
    {
        this.successor = successor;
    }

    public abstract void ProcessRequest(Purchase purchase);
}

// ConcreteHandler
class Manager : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 1000)
        {
            Console.WriteLine($"{nameof(Manager)} approved the purchase request #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

// Another ConcreteHandler
class Director : Approver
{
    public override void ProcessRequest(Purchase purchase)
    {
        if (purchase.Amount <= 5000)
        {
            Console.WriteLine($"{nameof(Director)} approved the purchase request #{purchase.Number}");
        }
        else if (successor != null)
        {
            successor.ProcessRequest(purchase);
        }
    }
}

// Request class
class Purchase
{
    public int Number { get; }
    public double Amount { get; }

    public Purchase(int number, double amount)
    {
        Number = number;
        Amount = amount;
    }
}

class Program
{
    static void Main()
    {
        Approver manager = new Manager();
        Approver director = new Director();

        manager.SetSuccessor(director);

        Purchase purchase1 = new Purchase(1, 800);
        Purchase purchase2 = new Purchase(2, 3500);
        Purchase purchase3 = new Purchase(3, 7000);

        manager.ProcessRequest(purchase1);
        manager.ProcessRequest(purchase2);
        manager.ProcessRequest(purchase3);
    }
}
