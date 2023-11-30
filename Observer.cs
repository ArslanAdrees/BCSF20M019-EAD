using System;
using System.Collections.Generic;

// Subject (Observable)
interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// ConcreteSubject
class ConcreteSubject : ISubject
{
    private readonly List<IObserver> _observers = new List<IObserver>();
    private int _state;

    public int State
    {
        get => _state;
        set
        {
            _state = value;
            NotifyObservers();
        }
    }

    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(State);
        }
    }
}

// Observer
interface IObserver
{
    void Update(int state);
}

// ConcreteObserver
class ConcreteObserver : IObserver
{
    private readonly string _name;

    public ConcreteObserver(string name)
    {
        _name = name;
    }

    public void Update(int state)
    {
        Console.WriteLine($"{_name} received update. New State: {state}");
    }
}

class Program
{
    static void Main()
    {
        ConcreteSubject subject = new ConcreteSubject();

        ConcreteObserver observerA = new ConcreteObserver("Observer A");
        ConcreteObserver observerB = new ConcreteObserver("Observer B");

        subject.AddObserver(observerA);
        subject.AddObserver(observerB);

        subject.State = 1;
        subject.State = 2;

        subject.RemoveObserver(observerA);

        subject.State = 3;
    }
}
