using System;

// Mediator interface
interface IChatMediator
{
    void SendMessage(string message, Participant participant);
}

// Colleague interface
abstract class Participant
{
    protected IChatMediator Mediator;
    public string Name { get; }

    public Participant(string name, IChatMediator mediator)
    {
        Name = name;
        Mediator = mediator;
    }

    public abstract void Receive(string message);
    public abstract void Send(string message);
}

// ConcreteMediator
class ChatMediator : IChatMediator
{
    public void SendMessage(string message, Participant participant)
    {
        Console.WriteLine($"{participant.Name} sent: {message}");
    }
}

// ConcreteColleague
class ConcreteParticipant : Participant
{
    public ConcreteParticipant(string name, IChatMediator mediator) : base(name, mediator) { }

    public override void Receive(string message)
    {
        Console.WriteLine($"{Name} received: {message}");
    }

    public override void Send(string message)
    {
        Mediator.SendMessage(message, this);
    }
}

class Program
{
    static void Main()
    {
        IChatMediator mediator = new ChatMediator();

        Participant participantA = new ConcreteParticipant("Participant A", mediator);
        Participant participantB = new ConcreteParticipant("Participant B", mediator);

        participantA.Send("Hello from Participant A");
        participantB.Send("Hi from Participant B");
    }
}
