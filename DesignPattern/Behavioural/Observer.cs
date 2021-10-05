using System;
using System.Collections.Generic;

namespace DesignPattern.Behavioural
{
    //Observer lets you define a subscription mechanism to notify multiple objects about any events that happen to the object they’re observing.

    public interface ISubscriber
    {
        void Update(Publisher data);

        string Name { get; }
    }

    public class ConcreteSubscriber :  ISubscriber
    {
        public string Name { get; }

        public ConcreteSubscriber(string name)
            => Name = name;

        public void Update(Publisher data)
        {
            Console.WriteLine($"{Name} Subscriber notified");
        }
    }

    public class Publisher
    {
        private Dictionary<string, ISubscriber> _subscribersDico = new Dictionary<string, ISubscriber>();

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

        public void UpdateData()
        {
            NotifySubscribers();
        }

        public void NotifySubscribers()
        {
            foreach (var subscriber in _subscribersDico.Values)
                subscriber.Update(this);
        }
    }


    public class ObserverClient
    {
        private readonly Publisher _publisher = new Publisher();

        public ObserverClient()
        {
            _publisher.Subscribe(new ConcreteSubscriber("Adam"));
            _publisher.Subscribe(new ConcreteSubscriber("Lise"));
        }

        public void UpdatePublisher()
        {
            _publisher.UpdateData();
        }
    }
}
