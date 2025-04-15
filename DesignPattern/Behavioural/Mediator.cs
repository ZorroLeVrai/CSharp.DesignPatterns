using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Mediator lets you reduce chaotic dependencies between objects.
/// The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.
/// </summary>
public interface IActor
{
    IReadOnlyList<string> ReceivedMessages { get; }
    void SendMessage(string message);
    void ReceiveMessage(string message);
}

public abstract record BaseActor : IActor
{
    protected readonly List<string> _receivedMessages = new List<string>();
    public IReadOnlyList<string> ReceivedMessages => _receivedMessages;

    public abstract void SendMessage(string message);

    public abstract void ReceiveMessage(string message);
}

public record ActorAlpha(string Name, Mediator Intermediate) : BaseActor
{
    public override void ReceiveMessage(string message)
    {
        _receivedMessages.Add($"(Alpha) {Name} received message: {message}");
    }

    public override void SendMessage(string message)
    {
        Intermediate.SendMessage(message);
    }
}

public record ActorBeta(string Name, Mediator Intermediate) : BaseActor
{
    public override void ReceiveMessage(string message)
    {
        _receivedMessages.Add($"(Beta) {Name} received message: {message}");
    }

    public override void SendMessage(string message)
    {
        Intermediate.SendMessage(message);
    }
}

public class Mediator
{
    private readonly List<IActor> _actors = new();

    public void Register(IActor actor)
    {
        _actors.Add(actor);
    }

    public void SendMessage(string message)
    {
        _actors.ForEach(x => x.ReceiveMessage(message));
    }
}


public class MediatorClient : AbstractRunner
{
    private readonly Mediator mediator = new();

    public override void Run()
    {
        var keny = new ActorAlpha("Keny", mediator);
        var john = new ActorAlpha("John", mediator);
        var jane = new ActorBeta("Jane", mediator);

        mediator.Register(keny);
        mediator.Register(john);
        mediator.Register(jane);

        keny.SendMessage("Calin");

        Assert.Single(keny.ReceivedMessages);
        Assert.Single(john.ReceivedMessages);
        Assert.Single(jane.ReceivedMessages);

        Assert.Equal("(Alpha) Keny received message: Calin", keny.ReceivedMessages[0]);
        Assert.Equal("(Alpha) John received message: Calin", john.ReceivedMessages[0]);
        Assert.Equal("(Beta) Jane received message: Calin", jane.ReceivedMessages[0]);
    }
}
