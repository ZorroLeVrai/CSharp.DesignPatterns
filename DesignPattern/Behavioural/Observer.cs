using System;
using System.Collections.Generic;
using Xunit;

namespace DesignPattern.Behavioural;

/// <summary>
/// Observer lets you define a subscription mechanism to notify multiple objects about any events that happen
/// to the object they’re observing.
/// </summary>
public interface ISubscriber
{
    IReadOnlyList<int> NotificationData { get; }

    void Update(Publisher data);

    string Name { get; }
}

public class ConcreteSubscriber : ISubscriber
{
    private readonly List<int> _notificationData = new();

    public string Name { get; }

    public IReadOnlyList<int> NotificationData { get => _notificationData; }

    public ConcreteSubscriber(string name)
        => Name = name;

    public void Update(Publisher data)
    {
        _notificationData.Add(data.MyValue);
    }
}

public class Publisher
{
    private readonly Dictionary<string, ISubscriber> _subscribersDico = new();

    public int MyValue { get; private set; }

    public void Subscribe(ISubscriber subscriber)
    {
        if (_subscribersDico.ContainsKey(subscriber.Name))
            return;

        _subscribersDico.Add(subscriber.Name, subscriber);
    }

    public void UnSubscribe(ISubscriber subscriber)
    {
        _subscribersDico.Remove(subscriber.Name);
    }

    public void UpdateData(int value)
    {
        MyValue = value;
        NotifySubscribers();
    }

    public void NotifySubscribers()
    {
        foreach (var subscriber in _subscribersDico.Values)
            subscriber.Update(this);
    }
}


public class ObserverClient : AbstractRunner
{
    public override void Run()
    {
        Publisher _publisher = new();

        var john = new ConcreteSubscriber("John");
        var jane = new ConcreteSubscriber("Jane");

        // Subscribe
        _publisher.Subscribe(john);
        _publisher.Subscribe(jane);

        _publisher.UpdateData(1);

        Assert.Equal(1, john.NotificationData.Count);
        Assert.Equal(1, jane.NotificationData.Count);

        Assert.Equal(1, john.NotificationData[0]);
        Assert.Equal(1, jane.NotificationData[0]);
    }
}
