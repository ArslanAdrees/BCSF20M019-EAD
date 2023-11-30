using System;
using System.Collections;

// Aggregate interface
interface IAbstractCollection
{
    IIterator CreateIterator();
}

// Iterator interface
interface IIterator
{
    bool HasNext();
    object Next();
}

// ConcreteAggregate
class ConcreteCollection : IAbstractCollection
{
    private ArrayList items = new ArrayList();

    public void AddItem(object item)
    {
        items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count
    {
        get { return items.Count; }
    }

    public object this[int index]
    {
        get { return items[index]; }
    }
}

// ConcreteIterator
class ConcreteIterator : IIterator
{
    private ConcreteCollection collection;
    private int index = 0;

    public ConcreteIterator(ConcreteCollection collection)
    {
        this.collection = collection;
    }

    public bool HasNext()
    {
        return index < collection.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            return collection[index++];
        }
        else
        {
            throw new InvalidOperationException("End of collection reached.");
        }
    }
}

class Program
{
    static void Main()
    {
        ConcreteCollection collection = new ConcreteCollection();
        collection.AddItem(1);
        collection.AddItem(2);
        collection.AddItem(3);

        IIterator iterator = collection.CreateIterator();

        while (iterator.HasNext())
        {
            Console.WriteLine(iterator.Next());
        }
    }
}

